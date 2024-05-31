$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Inventories/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Inventories/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Inventories/DeleteModal');

    function createInventoryRow(inventory) {
        console.log(inventory);
        var dateInfo;
        if (inventory.lastModificationTime == null) {
            dateInfo = inventory.creationTime.split(/[T.]/);
        } else {
            dateInfo = inventory.lastModificationTime.split(/[T.]/);
        }     
        var dateDisplay = `${dateInfo[0]}  (${dateInfo[1]})`;
        return `
            <tr>
                <td>${inventory.rawMaterialName}</td>
                <td>${inventory.stockQuantity}</td>
                <td>${dateDisplay}</td>
                <td>
                    <button class="btn btn-primary edit-button" data-id="${inventory.id}">
                        <i class="fas fa-edit"></i> ${l('Edit')}
                    </button>
                    <button class="btn btn-danger delete-button" data-id="${inventory.id}">
                        <i class="fas fa-trash"></i> ${l('Delete')}
                    </button>
                </td>
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
        debugger;
        var inputValue = $('#Inventory_LastRestockDate');
        var newDate = Date(inputValue.value).toISOString();
        inputValue.value = newDate;

        loadInventories();
    });

    editModal.onResult(function () {
        loadInventories();
    });

    $('#NewInventoryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadInventories(); // Load initial raw materials
});
