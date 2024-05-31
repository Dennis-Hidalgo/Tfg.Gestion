$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Invoices/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Invoices/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Invoices/DeleteModal');

    function createInvoiceRow(invoice) {
        return `
        <tr>
            <td>${invoice.invoiceNumber}</td>
            <td>${invoice.order}</td>
            <td>${invoice.issueDate}</td>
            <td>${invoice.totalAmount}</td>
            <td>${invoice.status}</td>
            <td>
                <button class="btn btn-primary edit-button" data-id="${invoice.id}">
                    <i class="fas fa-edit"></i> ${l('Edit')}
                </button>
                <button class="btn btn-danger delete-button" data-id="${invoice.id}">
                    <i class="fas fa-trash"></i> ${l('Delete')}
                </button>
            </td>
        </tr>`;
    }


    function loadInvoices() {
        var InvoicesTable = $('#InvoicesList tbody');
        InvoicesTable.empty();

        var searchValue = $('#searchInput').val().toLowerCase();

        abp.ajax({
            url: abp.appPath + 'api/app/invoice',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (Invoice) {
                    if (Invoice.name.toLowerCase().includes(searchValue)) { // Filtrar por título en el lado del cliente
                        InvoicesTable.append(createInvoiceRow(Invoice));
                    }
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var InvoiceId = $(this).data('id');
                    editModal.open({ id: InvoiceId });
                });

                $('.delete-button').click(function () {
                    var InvoiceId = $(this).data('id');
                    openDeleteModal(InvoiceId);
                });
            }
        });
    }

    function openDeleteModal(InvoiceId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/invoice/' + InvoiceId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadInvoices();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadInvoices();
    });

    $('#categorySelect').change(function () {
        loadInvoices();
    });

    createModal.onResult(function () {
        loadInvoices();
    });

    editModal.onResult(function () {
        loadInvoices();
    });

    $('#NewInvoiceButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadInvoices(); // Load initial products
});

