$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Inventories/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Inventories/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Inventories/DeleteModal');

    function createInventoryRow(inventory) {
        const hasEditPermission = abp.auth.isGranted('Gestion.Inventories.Edit');
        const hasDeletePermission = abp.auth.isGranted('Gestion.Inventories.Delete');

        let actionButtons = '';

        if (hasEditPermission) {
            actionButtons += `
            <button class="btn btn-primary edit-button" data-id="${inventory.id}">
                <i class="fas fa-edit"></i> ${l('Edit')}
            </button>`;
        }

        if (hasDeletePermission) {
            actionButtons += `
            <button class="btn btn-danger delete-button" data-id="${inventory.id}">
                <i class="fas fa-trash"></i> ${l('Delete')}
            </button>`;
        }

        if (!hasEditPermission && !hasDeletePermission) {
            actionButtons = `<span>${l('NoPermissions')}</span>`;
        }

        var dateInfo;
        if (inventory.lastModificationTime == null) {
            dateInfo = inventory.creationTime.split(/[T.]/);
        } else {
            dateInfo = inventory.lastModificationTime.split(/[T.]/);
        }
        var dateDisplay = `${dateInfo[0]} (${dateInfo[1]})`;

        return `
        <tr>
            <td>${inventory.rawMaterialName}</td>
            <td>${inventory.stockQuantity}</td>
            <td>${dateDisplay}</td>
            <td>${actionButtons}</td>
        </tr>`;
    }


    function loadInventories() {
        var inventoriesTable = $('#InventoriesList tbody');
        inventoriesTable.empty();

        abp.ajax({
            url: abp.appPath + 'api/app/inventory',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (inventory) {
                    inventoriesTable.append(createInventoryRow(inventory));
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var inventoryId = $(this).data('id');
                    editModal.open({ id: inventoryId });
                });

                $('.delete-button').click(function () {
                    var inventoryId = $(this).data('id');
                    openDeleteModal(inventoryId);
                });
            }
        });
    }

    function openDeleteModal(inventoryId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/inventory/' + inventoryId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadInventories();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadInventories();
    });

    $('#categorySelect').change(function () {
        loadInventories();
    });

    createModal.onResult(function () {
        loadInventories();
    });

    editModal.onResult(function () {
        loadInventories();
    });
    $('#NewInventoryButton').click(function (e) {
        e.preventDefault();
        console.log(createModal);
        createModal.open();
    });

    loadInventories(); // Load initial raw materials
});
