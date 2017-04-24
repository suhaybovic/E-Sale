using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Sale.ViewModel
{
    public enum ProductTypeEnum
    {
        Clothing,
        
        PhonesAccessories,

        [Display(Name = "Computer & Office")]
        ComputerOffice,


        [Display(Name = "Consumer & Electronics")]
        ConsumerElectronics,
        JewelryWatches,
        HomeGarden,
        Bagsshoes,
        ToysKids,
        SportsOutdoors,
        [Display(Name = "Health & Beauty")]
        HealthBeauty,
        [Display(Name = "Automobiles & Motorcycles")]
        AutomobilesMotorcycles,


    }
}