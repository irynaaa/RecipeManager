using BLL.Abstract;
using BLL.ViewModels;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class RecipeProdRecordProvider: IRecipeProdRecordProvider
    {
        IRecipeProdRecordRepository _recipeProdRecordRepository;

        public RecipeProdRecordProvider(IRecipeProdRecordRepository recipeProdRecordRepository)
        {
            _recipeProdRecordRepository = recipeProdRecordRepository;
        }

        public IEnumerable<RecipeProdRecordsViewModel> GetRecipeProdRecords()
        {
            var model = _recipeProdRecordRepository.RecipeProdRecords()
                .Select(c => new RecipeProdRecordsViewModel
                {
                    Id = c.Id,
                    ProductId=c.ProductId,
                    RecipeId=c.RecipeId,
                    Weight=c.Weight
            
        });

            return model.AsEnumerable();
        }
    }
}
