using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Tfg.Gestion.Orders
{
    public class OrderAppService :
    CrudAppService<
    Order, //The Order entity
    OrderDto, //Used to show orders
    Guid, //Primary key of the order entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateOrderDto>, //Used to create/update a order
IOrderAppService //implement the IOrderAppService
    {
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly ICurrentUser _currentUserRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        public OrderAppService(IRepository<Order, Guid> repository, IRepository<Customer, Guid> customerRepository, ICurrentUser currentUserRepository, IIdentityUserRepository identityUserRepository)
        : base(repository)
        {
            GetPolicyName = GestionPermissions.Orders.Default;
            GetListPolicyName = GestionPermissions.Orders.Default;
            CreatePolicyName = GestionPermissions.Orders.Create;
            UpdatePolicyName = GestionPermissions.Orders.Edit;
            DeletePolicyName = GestionPermissions.Orders.Delete;
            _customerRepository = customerRepository;
            _currentUserRepository = currentUserRepository;
            _identityUserRepository = identityUserRepository;
        }

        public override async Task<OrderDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Order> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join orders and customers
            var query = from order in queryable
                        join customer in await _customerRepository.GetQueryableAsync() on order.CustomerId equals customer.Id
                        where order.Id == id
                        select new { order, customer };

            //Execute the query and get the order with customer
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            var orderDto = ObjectMapper.Map<Order, OrderDto>(queryResult.order);
            orderDto.CustomerName = queryResult.customer.FirstName;
            return orderDto;
        }

        public override async Task<PagedResultDto<OrderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Order> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join orders and customers
            var query = from order in queryable
                        join customer in await _customerRepository.GetQueryableAsync() on order.CustomerId equals customer.Id
                        select new { order, customer };

            
            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of OrderDto objects
            var orderDtos = queryResult.Select(x =>
            {
                var orderDto = ObjectMapper.Map<Order, OrderDto>(x.order);
                orderDto.CustomerName = x.customer.FirstName;
                var userGuid = orderDto.CreatorId;
                orderDto.UserName = _identityUserRepository.GetAsync((Guid)userGuid).Result.Name;
                return orderDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<OrderDto>(
                totalCount,
                orderDtos
            );
        }

        public async Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync()
        {
            var customers = await _customerRepository.GetListAsync();
            return new ListResultDto<CustomerLookupDto>(
                ObjectMapper.Map<List<Customer>, List<CustomerLookupDto>>(customers)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"order.{nameof(Order.Id)}";
            }

            if (sorting.Contains("customerName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "customerName",
                    "customer.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"order.{sorting}";
        }
    }
}
