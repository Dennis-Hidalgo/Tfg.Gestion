$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Products/DeleteModal');

    function createCardItem(product) {
        return `
            <div class="col">
                <div class="card">
                    <img src="${product.image}" class="card-img-top" alt="${product.title}">
                    <div class="card-body">
                        <h5 class="card-title">${product.title}</h5>
                        <p class="card-text">${product.description}</p>
                        <p class="card-text">${l('Price')}: ${product.price}</p>
                        <p class="card-text">${l('Category')}: ${product.myCategory}</p>
                        <p class="card-text">${l('Stock')}: ${product.stock}</p>
                        <button class="btn btn-primary edit-button" data-id="${product.id}">
                            <i class="fas fa-edit"></i> ${l('Edit')}
                        </button>
                        <button class="btn btn-danger delete-button" data-id="${product.id}">
                            <i class="fas fa-trash"></i> ${l('Delete')}
                        </button>
                    </div>
                </div>
            </div>`;
    }

    function loadProducts() {
        debugger
        var productsList = $('#ProductsList');
        
        productsList.empty();

        var searchValue = $('#searchInput').val().toLowerCase(); // Convertir el valor de búsqueda a minúsculas
        console.log(abp.appPath + 'api/app/product')
        abp.ajax({
            url: abp.appPath + 'api/app/product',
            type: 'GET',
            success: function (result) {
                console.log(result.items)
                result.items.forEach(function (product) {
                    if (product.title.toLowerCase().includes(searchValue)) { // Filtrar por título en el lado del cliente
                        productsList.append(createCardItem(product));
                    }
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var productId = $(this).data('id');
                    editModal.open({ id: productId });
                });

                $('.delete-button').click(function () {
                    var productId = $(this).data('id');
                    openDeleteModal(productId);
                });
            }
        });
    }

    function openDeleteModal(productId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/product/' + productId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadProducts();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadProducts();
    });

    $('#categorySelect').change(function () {
        loadProducts();
    });

    createModal.onResult(function () {
        loadProducts();
    });

    editModal.onResult(function () {
        loadProducts();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadProducts(); // Load initial products
});
