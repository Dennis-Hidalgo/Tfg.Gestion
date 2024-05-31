$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'RawMaterials/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'RawMaterials/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'RawMaterials/DeleteModal');

    function createRawMaterialRow(rawMaterial) {
        return `
            <tr>
                <td>${rawMaterial.name}</td>
                <td>${rawMaterial.description}</td>
                <td>${rawMaterial.productProviderName}</td>
                <td>
                    <button class="btn btn-primary edit-button" data-id="${rawMaterial.id}">
                        <i class="fas fa-edit"></i> ${l('Edit')}
                    </button>
                    <button class="btn btn-danger delete-button" data-id="${rawMaterial.id}">
                        <i class="fas fa-trash"></i> ${l('Delete')}
                    </button>
                </td>
            </tr>`;
    }

    function loadRawMaterials() {
        var rawMaterialsTable = $('#RawMaterialsList tbody');
        rawMaterialsTable.empty();

        abp.ajax({
            url: abp.appPath + 'api/app/raw-material',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (rawMaterial) {
                    rawMaterialsTable.append(createRawMaterialRow(rawMaterial));
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var rawMaterialId = $(this).data('id');
                    editModal.open({ id: rawMaterialId });
                });

                $('.delete-button').click(function () {
                    var rawMaterialId = $(this).data('id');
                    openDeleteModal(rawMaterialId);
                });
            }
        });
    }

    function openDeleteModal(rawMaterialId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/raw-material/' + rawMaterialId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadRawMaterials();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadRawMaterials();
    });

    $('#categorySelect').change(function () {
        loadRawMaterials();
    });

    createModal.onResult(function () {
        loadRawMaterials();
    });

    editModal.onResult(function () {
        loadRawMaterials();
    });

    $('#NewRawMaterialButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadRawMaterials(); // Load initial raw materials
});
