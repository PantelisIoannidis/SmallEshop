using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure
{
    public class DbInit
    {
        string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam pellentesque dolor odio, quis vehicula dui tristique in. Sed gravida, justo sit amet lobortis efficitur, lorem ex vulputate risus, eget pulvinar leo tellus id metus. Nam eros tellus, vulputate maximus hendrerit eu, tempor ut erat. \n Morbi sit amet convallis tellus, sed blandit nisl. Mauris imperdiet, orci ac ullamcorper interdum, massa dolor dapibus velit, vitae lobortis elit nisl eu sapien.\n Nulla in lectus sit amet nunc tincidunt lobortis. In pharetra dui varius, aliquam nisl ac, sagittis nunc. Nam laoreet, orci ut rhoncus pulvinar, felis eros ornare sapien, a dignissim magna orci at arcu. Suspendisse aliquet convallis leo, vitae auctor erat auctor a. \nProin lobortis dignissim ante, eget ultrices dui condimentum non. Nunc venenatis cursus magna, quis placerat ex aliquet ut. Curabitur ac pretium nibh. Suspendisse potenti.Donec et sapien at nunc gravida scelerisque sed vel purus.Phasellus posuere est ut elementum aliquet.\n Morbi justo lectus, hendrerit at venenatis sit amet, venenatis eu arcu.Etiam nec odio eu sapien gravida hendrerit sit amet eget odio.In velit ex, vulputate eget mattis ac, aliquam nec quam.Nullam egestas tortor massa, nec commodo velit varius et.Etiam orci purus, dictum eu tellus id, ultrices mollis turpis. Maecenas scelerisque justo nec leo consectetur rhoncus.In hac habitasse platea dictumst.In eget dolor sapien.\n In faucibus tortor vitae porta imperdiet. In pellentesque ac arcu ac posuere. Cras vel sollicitudin augue. Aliquam blandit placerat interdum. Nullam ac massa nibh. Integer imperdiet purus sed tellus sodales, quis consequat enim sollicitudin. Nunc faucibus lorem est, eget tempor eros tincidunt eu.Maecenas fringilla mi id leo ultrices auctor.Suspendisse massa justo, placerat vel gravida venenatis, fermentum quis lacus.Nam et pulvinar massa. Ut pharetra, risus et fringilla aliquam, elit enim porttitor elit, sed convallis felis justo nec augue. Curabitur sit amet dignissim sapien.Suspendisse facilisis at lacus id sagittis. Donec facilisis lectus neque, vel tincidunt urna imperdiet ultrices.Nulla nec ipsum purus. Duis neque erat, suscipit quis dui eu, iaculis feugiat tortor.Proin tempus at ipsum vitae vehicula. Morbi at libero quis lectus aliquam aliquam.\n Quisque ut mauris cursus libero aliquam rhoncus suscipit ac diam. Pellentesque sit amet nibh auctor, dignissim diam et, sollicitudin lacus. Cras vel placerat lorem, ac facilisis arcu.Etiam elit magna, cursus vitae eros non, rhoncus convallis libero. ";
        public DbInit(ApplicationDbContext context)
        {
            this.context = context;
        }
        private static Dictionary<string, Category> categories = new Dictionary<string, Category>();
        private static Dictionary<string, Brand> brands = new Dictionary<string, Brand>();
        private static Dictionary<string, ItemImage> itemImages = new Dictionary<string, ItemImage>();
        private readonly ApplicationDbContext context;

        public async Task SeedAsync()
        {
            try
            {
             if (!context.Brands.Any())
                await context.Brands.AddRangeAsync(Brands.Select(c => c.Value));

            if (!context.Categories.Any())
                await context.Categories.AddRangeAsync(Categories.Select(c => c.Value));

            if (!context.ItemImages.Any())
                await context.ItemImages.AddRangeAsync(itemImages.Select(c => c.Value));

            if (!context.Items.Any())
            {
                    var items = new Item[]
                {
                    new Item{
                        //ImageName="black-ceramic-cups-173955.jpg",
                        //ImageThumbnailName="black-ceramic-cups-173955.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("black-ceramic-cups-173955")).ToList(),
                        Category=Categories["Mugs"],
                        Brand=Brands["Solx"],
                        ItemName="Black Ceramic Cup",
                        ShortDescription="Black Ceramic Cup",
                        LongDescription=loremIpsum,
                        Price=7M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="brown-ceramic-cups-50676.jpg",
                        //ImageThumbnailName="brown-ceramic-cups-50676.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("brown-ceramic-cups-50676")).ToList(),
                        Category=Categories["Mugs"],
                        Brand=Brands["Solx"],
                        ItemName="Brown Ceramic Cup",
                        ShortDescription="Brown Ceramic Cup",
                        LongDescription=loremIpsum,
                        Price=7M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="heather-schwartz-493955-unsplash.jpg",
                        //ImageThumbnailName="heather-schwartz-493955-unsplash.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("heather-schwartz-493955-unsplash")).ToList(),
                        Category=Categories["Mugs"],
                        Brand=Brands["Esster"],
                        ItemName="Heather Black",
                        ShortDescription="Heather Black",
                        LongDescription=loremIpsum,
                        Price=7.5M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="matthew-sleeper-124918-unsplash.jpg",
                        //ImageThumbnailName="matthew-sleeper-124918-unsplash.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("matthew-sleeper-124918-unsplash")).ToList(),
                        Category=Categories["Mugs"],
                        Brand=Brands["Esster"],
                        ItemName="Matthew Sleeper",
                        ShortDescription="Matthew Sleeper",
                        LongDescription=loremIpsum,
                        Price=8.5M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="ryan-riggins-216051-unsplash.jpg",
                        //ImageThumbnailName="ryan-riggins-216051-unsplash.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("ryan-riggins-216051-unsplash")).ToList(),
                        Category=Categories["Mugs"],
                        Brand=Brands["Esster"],
                        ItemName="Ryan Riggins",
                        ShortDescription="Ryan Riggins",
                        LongDescription=loremIpsum,
                        Price=8M,
                        IsAvailable=true
                    },

                    new Item{
                        //ImageName="blank-1886001_1920.png",
                        //ImageThumbnailName="blank-1886001_1920.png",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("blank-1886001_1920")).ToList(),
                        Category=Categories["T-Shirts"],
                        Brand=Brands["RetroPl"],
                        ItemName="Black T-Shirt",
                        ShortDescription="Black T-Shirt",
                        LongDescription=loremIpsum,
                        Price=15M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="blank-1886008_1920.png",
                        //ImageThumbnailName="blank-1886008_1920.png",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("blank-1886008_1920")).ToList(),
                        Category=Categories["T-Shirts"],
                        Brand=Brands["RetroPl"],
                        ItemName="Red T-Shirt",
                        ShortDescription="Red T-Shirt",
                        LongDescription=loremIpsum,
                        Price=15M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="blank-1886013_1920.png",
                        //ImageThumbnailName="blank-1886013_1920.png",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("blank-1886013_1920")).ToList(),
                        Category=Categories["T-Shirts"],
                        Brand=Brands["RetroPl"],
                        ItemName="White T-Shirt",
                        ShortDescription="White T-Shirt",
                        LongDescription=loremIpsum,
                        Price=15M,
                        IsAvailable=true
                    },
                    new Item{
                        //ImageName="parker-burchfield-224850-unsplash.jpg",
                        //ImageThumbnailName="parker-burchfield-224850-unsplash.jpg",
                        ItemImages = ItemImages.Select(c => c.Value).ToList().Where(x => x.ImageName.StartsWith("parker-burchfield-224850-unsplash")).ToList(),
                        Category=Categories["T-Shirts"],
                        Brand=Brands["RetroPl"],
                        ItemName="T-Shirt Collection",
                        ShortDescription="T-Shirt Collection",
                        LongDescription=loremIpsum,
                        Price=62M,
                        IsAvailable=true
                    },
                };
                context.Items.AddRange(items);
            }

            context.SaveChanges();
        }
        catch(Exception ex)
            {
            }
        }

        public static Dictionary<string, ItemImage> ItemImages
        {
            get
            {
                if (!itemImages.Any())
                {
                    var itemImagesList = new ItemImage[]
                    {
                        new ItemImage {
                            ImageName="black-ceramic-cups-173955",
                            PhotoThumbnailUrl="black-ceramic-cups-173955.jpg",
                            PhotoUrl="black-ceramic-cups-173955.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="black-ceramic-cups-173955-1",
                            PhotoThumbnailUrl="black-ceramic-cups-173955-1.jpg",
                            PhotoUrl="black-ceramic-cups-173955-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="black-ceramic-cups-173955-2",
                            PhotoThumbnailUrl="black-ceramic-cups-173955-2.jpg",
                            PhotoUrl="black-ceramic-cups-173955-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="black-ceramic-cups-173955-3",
                            PhotoThumbnailUrl="black-ceramic-cups-173955-3.jpg",
                            PhotoUrl="black-ceramic-cups-173955-3.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="black-ceramic-cups-173955-4",
                            PhotoThumbnailUrl="black-ceramic-cups-173955-4.jpg",
                            PhotoUrl="black-ceramic-cups-173955-4.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="brown-ceramic-cups-50676",
                            PhotoThumbnailUrl="brown-ceramic-cups-50676.jpg",
                            PhotoUrl="brown-ceramic-cups-50676.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="brown-ceramic-cups-50676-1",
                            PhotoThumbnailUrl="brown-ceramic-cups-50676-1.jpg",
                            PhotoUrl="brown-ceramic-cups-50676-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="brown-ceramic-cups-50676-2",
                            PhotoThumbnailUrl="brown-ceramic-cups-50676-2.jpg",
                            PhotoUrl="brown-ceramic-cups-50676-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="heather-schwartz-493955-unsplash",
                            PhotoThumbnailUrl="heather-schwartz-493955-unsplash.jpg",
                            PhotoUrl="heather-schwartz-493955-unsplash.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="heather-schwartz-493955-unsplash-1",
                            PhotoThumbnailUrl="heather-schwartz-493955-unsplash-1.jpg",
                            PhotoUrl="heather-schwartz-493955-unsplash-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="heather-schwartz-493955-unsplash-2",
                            PhotoThumbnailUrl="heather-schwartz-493955-unsplash-2.jpg",
                            PhotoUrl="heather-schwartz-493955-unsplash-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="matthew-sleeper-124918-unsplash",
                            PhotoThumbnailUrl="matthew-sleeper-124918-unsplash.jpg",
                            PhotoUrl="matthew-sleeper-124918-unsplash.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="matthew-sleeper-124918-unsplash-1",
                            PhotoThumbnailUrl="matthew-sleeper-124918-unsplash-1.jpg",
                            PhotoUrl="matthew-sleeper-124918-unsplash-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="matthew-sleeper-124918-unsplash-2",
                            PhotoThumbnailUrl="matthew-sleeper-124918-unsplash-2.jpg",
                            PhotoUrl="matthew-sleeper-124918-unsplash-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="ryan-riggins-216051-unsplash",
                            PhotoThumbnailUrl="ryan-riggins-216051-unsplash.jpg",
                            PhotoUrl="ryan-riggins-216051-unsplash.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="ryan-riggins-216051-unsplash-1",
                            PhotoThumbnailUrl="ryan-riggins-216051-unsplash-1.jpg",
                            PhotoUrl="ryan-riggins-216051-unsplash-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="ryan-riggins-216051-unsplash-2",
                            PhotoThumbnailUrl="ryan-riggins-216051-unsplash-2.jpg",
                            PhotoUrl="ryan-riggins-216051-unsplash-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886001_1920",
                            PhotoThumbnailUrl="blank-1886001_1920.png",
                            PhotoUrl="blank-1886001_1920.png",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886001_1920-1",
                            PhotoThumbnailUrl="blank-1886001_1920-1.png",
                            PhotoUrl="blank-1886001_1920-1.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886001_1920-2",
                            PhotoThumbnailUrl="blank-1886001_1920-2.png",
                            PhotoUrl="blank-1886001_1920-2.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886008_1920",
                            PhotoThumbnailUrl="blank-1886008_1920.png",
                            PhotoUrl="blank-1886008_1920.png",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886008_1920-1",
                            PhotoThumbnailUrl="blank-1886008_1920-1.png",
                            PhotoUrl="blank-1886008_1920-1.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886008_1920-2",
                            PhotoThumbnailUrl="blank-1886008_1920-2.png",
                            PhotoUrl="blank-1886008_1920-2.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886013_1920",
                            PhotoThumbnailUrl="blank-1886013_1920.png",
                            PhotoUrl="blank-1886013_1920.png",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886013_1920-1",
                            PhotoThumbnailUrl="blank-1886013_1920-1.png",
                            PhotoUrl="blank-1886013_1920-1.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="blank-1886013_1920-2",
                            PhotoThumbnailUrl="blank-1886013_1920-2.png",
                            PhotoUrl="blank-1886013_1920-2.png",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="parker-burchfield-224850-unsplash",
                            PhotoThumbnailUrl="parker-burchfield-224850-unsplash.jpg",
                            PhotoUrl="parker-burchfield-224850-unsplash.jpg",
                            DefaultImage=true,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="parker-burchfield-224850-unsplash-1",
                            PhotoThumbnailUrl="parker-burchfield-224850-unsplash-1.jpg",
                            PhotoUrl="parker-burchfield-224850-unsplash-1.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                        new ItemImage {
                            ImageName="parker-burchfield-224850-unsplash-2",
                            PhotoThumbnailUrl="parker-burchfield-224850-unsplash-2.jpg",
                            PhotoUrl="parker-burchfield-224850-unsplash-2.jpg",
                            DefaultImage=false,
                            PhotoDescription="Description Here"
                        },
                    };
                    foreach (var itemImage in itemImagesList)
                        itemImages.Add(itemImage.ImageName, itemImage);
                }
                return itemImages;
            }
        }
        
        public static Dictionary<string, Category> Categories
        {
            get {
                if (!categories.Any())
                {
                    var categoriesList = new Category[] {
                        new Category { CategoryName = "Mugs"},
                        new Category { CategoryName = "T-Shirts"}
                    };
                    foreach (var category in categoriesList)
                        categories.Add(category.CategoryName, category);

                } 
                return categories;
                
            }
        }

        public static Dictionary<string,Brand> Brands
        {
            get
            {
                if (!brands.Any())
                {
                    var brandList = new Brand[]
                    {
                    new Brand { BrandName="Solx"},
                    new Brand { BrandName="Esster"},
                    new Brand { BrandName="RetroPl"}
                    };
                    foreach (var brand in brandList)
                        brands.Add(brand.BrandName, brand);
                }
                return brands;
            }
            
        }
    }
}
