using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Models.ModelView
{
    public class GenericModelView<TEntity>
    {
        public TEntity Model { get; set; }
        public List<int> BindId { get; set; }
        public GenericModelView() {
            BindId = new List<int>();
    }
    }
}
