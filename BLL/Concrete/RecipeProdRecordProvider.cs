using BLL.Abstract;
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
    }
}
