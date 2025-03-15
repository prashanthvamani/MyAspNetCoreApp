using AutoMapper;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Models.Response;
using EPizzaHub.Repositories.Concrete;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Concrete
{
    public class ItemService : IItemService
    {
        private readonly IitemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IitemRepository iitemRepository, IMapper mapper)
        {
            _itemRepository = iitemRepository;
            _mapper = mapper;
        }
        public IEnumerable<ItemResponseModel> GetItems()
        {
            var items = _itemRepository.GetAll();

            //return new List<ItemResponseModel>();

            return _mapper.Map<IEnumerable<ItemResponseModel>>(items);
        }
    }
}
