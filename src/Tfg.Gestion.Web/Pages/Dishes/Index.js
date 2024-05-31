$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Dishes/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dishes/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Dishes/DeleteModal');

    function createDishRow(dish) {
        var dateInfo = dish.creationTime.split(/[T.]/);
        var dateDisplay = `${dateInfo[0]}  (${dateInfo[1]})`;
        console.log(dish)
        return `
            <tr>
                <td>${dish.name}</td>
                <td>${dish.description}</td>
                <td>${dish.price}</td>
                <td>${dateDisplay}</td>
                <td>${dish.category}</td>
                <!-- Agrega aquí cualquier otra columna que desees mostrar -->
                <td>
                    <button class="btn btn-primary edit-button" data-id="${dish.id}">
                        <i class="fas fa-edit"></i> ${l('Edit')}
                    </button>
                    <button class="btn btn-danger delete-button" data-id="${dish.id}">
                        <i class="fas fa-trash"></i> ${l('Delete')}
                    </button>
                </td>
            </tr>`;
    }

    function loadDishes() {
        var dishsTable = $('#DishesList tbody');
        dishsTable.empty();

        var searchValue = $('#searchInput').val().toLowerCase();

        abp.ajax({
            url: abp.appPath + 'api/app/dish',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (dish) {
                    if (dish.name.toLowerCase().includes(searchValue)) { // Filtrar por título en el lado del cliente
                        dishsTable.append(createDishRow(dish));
                    }
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var dishId = $(this).data('id');
                    editModal.open({ id: dishId });
                });

                $('.delete-button').click(function () {
                    var dishId = $(this).data('id');
                    openDeleteModal(dishId);
                });
            }
        });
    }

    function openDeleteModal(dishId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/dish/' + dishId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadDishes();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadDishes();
    });

    $('#categorySelect').change(function () {
        loadDishes();
    });

    createModal.onResult(function () {
        loadDishes();
    });

    editModal.onResult(function () {
        loadDishes();
    });

    $('#NewDishButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadDishes(); // Load initial products
});

