
$(function () {
    var l = abp.localization.getResource('Gestion');

    function createDishCard(dish) {
        return `
        <div class="col-md-4 mb-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">${dish.name}</h5>
                    <p class="card-text">${dish.description}</p>
                    <p class="card-text">${l('Price')}: ${dish.price}</p>
                    <input type="number" class="form-control" placeholder="${l('Quantity')}" min="1" value="1" />
                    <button class="btn btn-primary mt-2">${l('AddToOrder')}</button>
                </div>
            </div>
        </div>`;
    }

    function loadDishes() {
        var dishesList = $('#dishesContainer');

        abp.ajax({
            url: abp.appPath + 'api/app/dish',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (dish) {
                    var dishCard = createDishCard(dish);
                    dishesList.append(dishCard);
                });
            }
        });
    }
    function loadCustomers() {
        var customerSelect = $('#customerSelect');

        abp.ajax({
            url: abp.appPath + 'api/app/customer',
            type: 'GET',
            success: function (result) {
                result.items.forEach(function (customer) {
                    var option = $('<option>', {
                        value: customer.id,
                        text: customer.firstName + ' ' + customer.lastName
                    });
                    customerSelect.append(option);
                });
            }
        });
    }


    // Load dishes when the page loads
    loadDishes();
    loadCustomers();

    // Function to reload dishes
    var reloadDishes = function () {
        $('#dishesList').empty(); // Clear the dishes list before loading new ones
        loadDishes(); // Load dishes again
    };

    // Add logic for adding a new dish to the order
    $(document).on('click', '.btn-primary', function () {
        // Logic for adding the dish to the order
    });
});
