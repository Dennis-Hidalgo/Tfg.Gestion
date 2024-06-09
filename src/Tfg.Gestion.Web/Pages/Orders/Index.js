$(function () {
    var l = abp.localization.getResource('Gestion');

    var createModal = new abp.ModalManager(abp.appPath + 'Orders/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Orders/EditModal');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Orders/DeleteModal');

    function createOrderRow(order) {
        console.log(order);
        var dateInfo;
        if (order.lastModificationTime == null) {
            dateInfo = order.creationTime.split(/[T.]/);
        } else {
            dateInfo = order.lastModificationTime.split(/[T.]/);
        }     
        var dateDisplay = `${dateInfo[0]}  (${dateInfo[1]})`;
        return `
            <tr>
                <td>${order.pedidoId}</td>
                <td>${order.customerName}</td>
                <td>${order.userName}</td>
                <td>${order.orderStatus}</td>
                <td>${dateDisplay}</td>
                <td>
                    <button class="btn btn-primary edit-button" data-id="${order.id}">
                        <i class="fas fa-edit"></i> ${l('Edit')}
                    </button>
                    <button class="btn btn-danger delete-button" data-id="${order.id}">
                        <i class="fas fa-trash"></i> ${l('Delete')}
                    </button>
                </td>
            </tr>`;
    }

    function loadOrders() {
        var ordersTable = $('#OrdersList tbody');
        ordersTable.empty();

        abp.ajax({
            url: abp.appPath + 'api/app/order',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (order) {
                    ordersTable.append(createOrderRow(order));
                });

                // Attach event handlers for edit and delete buttons
                $('.edit-button').click(function () {
                    var orderId = $(this).data('id');
                    editModal.open({ id: orderId });
                });

                $('.delete-button').click(function () {
                    var orderId = $(this).data('id');
                    openDeleteModal(orderId);
                });
            }
        });
    }

    function openDeleteModal(orderId) {
        abp.message.confirm(
            l('AreYouSureToDelete'),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: abp.appPath + 'api/app/order/' + orderId,
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            loadOrders();
                        }
                    });
                }
            }
        );
    }

    $('#searchInput').on('input', function () {
        loadOrders();
    });

    $('#categorySelect').change(function () {
        loadOrders();
    });

    createModal.onResult(function () {
        loadOrders();
    });

    editModal.onResult(function () {
        loadOrders();
    });
    $('#NewOrderButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    loadOrders(); // Load initial raw materials
});
