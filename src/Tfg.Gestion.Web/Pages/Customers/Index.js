$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Customers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Customers/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Customers/DeleteModal');

    function createCustomerRow(customer) {
        const hasEditPermission = abp.auth.isGranted('Gestion.Customers.Edit');
        const hasDeletePermission = abp.auth.isGranted('Gestion.Customers.Delete');
        console.log(hasEditPermission);
        console.log(hasDeletePermission);

        let actionButtons = '';

        if (hasEditPermission) {
            actionButtons += `
            <button class="btn btn-primary edit-button" data-id="${customer.id}">
                <i class="fas fa-edit"></i> ${l('Edit')}
            </button>`;
        }

        if (hasDeletePermission) {
            actionButtons += `
            <button class="btn btn-danger delete-button" data-id="${customer.id}">
                <i class="fas fa-trash"></i> ${l('Delete')}
            </button>`;
        }

        if (!hasEditPermission && !hasDeletePermission) {
            actionButtons = `<span>${l('NoPermissions')}</span>`;
        }

        return `
        <tr>
            <td>${customer.firstName}</td>
            <td>${customer.lastName}</td>
            <td>${customer.address}</td>
            <td>${customer.phone}</td>
            <td>${customer.email}</td>
            <!-- Agrega aquí cualquier otra columna que desees mostrar -->
            <td>${actionButtons}</td>
        </tr>`;
    }



    function loadCustomers() {
        var customersTable = $('#CustomersList tbody');
        customersTable.empty();

        var searchValue = $('#searchInput').val().toLowerCase();

        abp.ajax({
            url: abp.appPath + 'api/app/customer',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (customer) {
                    if (customer.firstName.toLowerCase().includes(searchValue)) { // Filtrar por título en el lado del cliente
                        customersTable.append(createCustomerRow(customer));
                    }
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var customerId = $(this).data('id');
                    editModal.open({ id: customerId });
                });

                $('.delete-button').click(function () {
                    var customerId = $(this).data('id');
                    openDeleteModal(customerId);
                });
            }
        });
    }

    function openDeleteModal(customerId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/customer/' + customerId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadCustomers();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadCustomers();
    });

    $('#categorySelect').change(function () {
        loadCustomers();
    });

    createModal.onResult(function () {
        loadCustomers();
    });

    editModal.onResult(function () {
        loadCustomers();
    });

    $('#NewCustomerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadCustomers(); // Load initial products
});

