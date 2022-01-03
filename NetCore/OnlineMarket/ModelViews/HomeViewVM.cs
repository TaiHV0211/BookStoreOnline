using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.ModelViews
{
    public class HomeViewVM
    {
        public List<Post> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
      
    }
}
