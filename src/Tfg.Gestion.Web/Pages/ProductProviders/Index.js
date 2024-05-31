$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'ProductProviders/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ProductProviders/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'ProductProviders/DeleteModal');

    function createProductProviderRow(provider) {
        return `
            <tr>
                <td>${provider.name}</td>
                <td>${provider.address}</td>
                <td>${provider.phone}</td>
                <td>${provider.email}</td>
                <!-- Agrega aquí cualquier otra columna que desees mostrar -->
                <td>
                    <button class="btn btn-primary edit-button" data-id="${provider.id}">
                        <i class="fas fa-edit"></i> ${l('Edit')}
                    </button>
                    <button class="btn btn-danger delete-button" data-id="${provider.id}">
                        <i class="fas fa-trash"></i> ${l('Delete')}
                    </button>
                </td>
            </tr>`;
    }

    function loadProductProviders() {
        var productProvidersTable = $('#ProductProvidersList tbody');
        productProvidersTable.empty();

        var searchValue = $('#searchInput').val().toLowerCase();

        abp.ajax({
            url: abp.appPath + 'api/app/product-provider',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (productProvider) {
                    if (productProvider.name.toLowerCase().includes(searchValue)) { // Filtrar por título en el lado del cliente
                        productProvidersTable.append(createProductProviderRow(productProvider));
                    }
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var productProviderId = $(this).data('id');
                    editModal.open({ id: productProviderId });
                });

                $('.delete-button').click(function () {
                    var productProviderId = $(this).data('id');
                    openDeleteModal(productProviderId);
                });
            }
        });
    }

    function openDeleteModal(productProviderId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/product-provider/' + productProviderId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadProductProviders();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadProductProviders();
    });

    $('#categorySelect').change(function () {
        loadProductProviders();
    });

    createModal.onResult(function () {
        loadProductProviders();
    });

    editModal.onResult(function () {
        loadProductProviders();
    });

    $('#NewProductProviderButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadProductProviders(); // Load initial products
});

