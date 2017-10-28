using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class RecipeProdRecordProvider: IRecipeProdRecordProvider
    {
        IRecipeProdRecordProvider _recipeProdRecordProvider;

        public RecipeProdRecordProvider(IRecipeProdRecordProvider recipeProdRecordProvider)
        {
            _recipeProdRecordProvider = recipeProdRecordProvider;
        }
    }
}
