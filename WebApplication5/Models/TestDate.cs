using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class TestDate
    {

        static public void Init(ShopContext context)
        {

            if (!context.Bicycles.Any())
            {
                context.Bicycles.AddRange(

                    new Bicycle
                    {
                        Name = "Azimut Fara 24",
                        FrameSize = 15,
                        GearsQuantity = 1,
                        Price = 400,
                        Weight = 15,
                        WheelDiameter = 24,
                        Mnufacture = "Azimut",
                        IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."

                    },

                    new Bicycle
                    {
                        Name = "Azimut Fara 22",
                        FrameSize = 14,
                        GearsQuantity = 1,
                        Price = 350,
                        Weight = 15,
                        WheelDiameter = 22,
                        Mnufacture = "Azimut",
                        IamgeUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSaTfNJir_Cax7gfcVdIp0WUEsgI6kGuFBGsVuh6_OIEReBIC8qYASn6G6iYOPxhySaEEQ&usqp=CAU",
                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                    },

                        new Bicycle
                        {
                            Name = "Discovery Rider",
                            FrameSize = 16,
                            GearsQuantity = 21,
                            Price = 500,
                            Weight = 17,
                            WheelDiameter = 26,
                            Mnufacture = "Discovery",
                            IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5388.png",
                            Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                        },
                            new Bicycle
                            {
                                Name = " Discovery Rider",
                                FrameSize = 13,
                                GearsQuantity = 28,
                                Price = 400,
                                Weight = 16,
                                WheelDiameter = 26,
                                Mnufacture = "Azimut",
                                IamgeUrl = "http://pngimg.com/uploads/bicycle/bicycle_PNG5372.png",
                                Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                            },
                                new Bicycle
                                {
                                    Name = "Flint 24",
                                    FrameSize = 17,
                                    GearsQuantity = 16,
                                    Price = 356,
                                    Weight = 16,
                                    WheelDiameter = 24,
                                    Mnufacture = "Flint",
                                    IamgeUrl = "http://velo-delo.com.ua/image/cache/data/Optima/Optima%20Hunter-850x515.png",
                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                },
                                    new Bicycle
                                    {
                                        Name = "Flint 26",
                                        FrameSize = 15,
                                        GearsQuantity = 18,
                                        Price = 499,
                                        Weight = 17,
                                        WheelDiameter = 26,
                                        Mnufacture = "Flint",
                                        IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                    },
                                        new Bicycle
                                        {
                                            Name = "Azimut Fara 24",
                                            FrameSize = 15,
                                            GearsQuantity = 1,
                                            Price = 400,
                                            Weight = 15,
                                            WheelDiameter = 24,
                                            Mnufacture = "Azimut",
                                            IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                            Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                        },
                                              new Bicycle
                                              {
                                                  Name = " Discovery Rider",
                                                  FrameSize = 13,
                                                  GearsQuantity = 28,
                                                  Price = 400,
                                                  Weight = 16,
                                                  WheelDiameter = 26,
                                                  Mnufacture = "Azimut",
                                                  IamgeUrl = "http://pngimg.com/uploads/bicycle/bicycle_PNG5372.png",
                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                              },
                                                new Bicycle
                                                {
                                                    Name = "Azimut Fara 27",
                                                    FrameSize = 15,
                                                    GearsQuantity = 16,
                                                    Price = 600,
                                                    Weight = 16,
                                                    WheelDiameter = 27,
                                                    Mnufacture = "Azimut",
                                                    IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                },
                                                    new Bicycle
                                                    {
                                                        Name = "Azimut Blackmount 20",
                                                        FrameSize = 17,
                                                        GearsQuantity = 12,
                                                        Price = 350,
                                                        Weight = 18,
                                                        WheelDiameter = 20,
                                                        Mnufacture = "Azimut",
                                                        IamgeUrl = "https://velobarnaul.ru/upload/glossaryImages/820e35d660e98c20103508f4c8eacd65.png",
                                                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                    },
                                                          new Bicycle
                                                          {
                                                              Name = "Azimut Blackmount 24",
                                                              FrameSize = 13,
                                                              GearsQuantity = 1,
                                                              Price = 299,
                                                              Weight = 14,
                                                              WheelDiameter = 24,
                                                              Mnufacture = "Azimut",
                                                              IamgeUrl = "https://velobarnaul.ru/upload/glossaryImages/820e35d660e98c20103508f4c8eacd65.png",
                                                              Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                          },
                                                                new Bicycle
                                                                {
                                                                    Name = "Discovery Passion",
                                                                    FrameSize = 16,
                                                                    GearsQuantity = 24,
                                                                    Price = 600,
                                                                    Weight = 12,
                                                                    WheelDiameter = 22,
                                                                    Mnufacture = "Discovery",
                                                                    IamgeUrl = "https://alfasport.com.ua/Media/shop-8179/AtlanticProtonNX.png",
                                                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                },
                                                                      new Bicycle
                                                                      {
                                                                          Name = "Formula Smart 24",
                                                                          FrameSize = 17,
                                                                          GearsQuantity = 3,
                                                                          Price = 300,
                                                                          Weight = 16,
                                                                          WheelDiameter = 24,
                                                                          Mnufacture = "Formula",
                                                                          IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                          Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                      },
                                                                           new Bicycle
                                                                           {
                                                                               Name = "Formula Smart 26",
                                                                               FrameSize = 17,
                                                                               GearsQuantity = 21,
                                                                               Price = 399,
                                                                               Weight = 18,
                                                                               WheelDiameter = 26,
                                                                               Mnufacture = "Formula",
                                                                               IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                               Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                           },
                                                                              new Bicycle
                                                                              {
                                                                                  Name = "Formula Smart 27",
                                                                                  FrameSize = 20,
                                                                                  GearsQuantity = 34,
                                                                                  Price = 450,
                                                                                  Weight = 120,
                                                                                  WheelDiameter = 27,
                                                                                  Mnufacture = "Formula",
                                                                                  IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                              }, new Bicycle
                                                                              {
                                                                                  Name = "Azimut Fara 24",
                                                                                  FrameSize = 15,
                                                                                  GearsQuantity = 1,
                                                                                  Price = 400,
                                                                                  Weight = 15,
                                                                                  WheelDiameter = 24,
                                                                                  Mnufacture = "Azimut",
                                                                                  IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                              },

                               new Bicycle
                               {
                                   Name = "Azimut Fara 24",
                                   FrameSize = 15,
                                   GearsQuantity = 1,
                                   Price = 400,
                                   Weight = 15,
                                   WheelDiameter = 24,
                                   Mnufacture = "Azimut",
                                   IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                   Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."

                               },

                    new Bicycle
                    {
                        Name = "Azimut Fara 22",
                        FrameSize = 14,
                        GearsQuantity = 1,
                        Price = 350,
                        Weight = 15,
                        WheelDiameter = 22,
                        Mnufacture = "Azimut",
                        IamgeUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSaTfNJir_Cax7gfcVdIp0WUEsgI6kGuFBGsVuh6_OIEReBIC8qYASn6G6iYOPxhySaEEQ&usqp=CAU",
                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                    },

                        new Bicycle
                        {
                            Name = "Discovery Rider",
                            FrameSize = 16,
                            GearsQuantity = 21,
                            Price = 500,
                            Weight = 17,
                            WheelDiameter = 26,
                            Mnufacture = "Discovery",
                            IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5388.png",
                            Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                        },
                            new Bicycle
                            {
                                Name = " Discovery Rider",
                                FrameSize = 13,
                                GearsQuantity = 28,
                                Price = 400,
                                Weight = 16,
                                WheelDiameter = 26,
                                Mnufacture = "Azimut",
                                IamgeUrl = "http://pngimg.com/uploads/bicycle/bicycle_PNG5372.png",
                                Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                            },
                                new Bicycle
                                {
                                    Name = "Flint 24",
                                    FrameSize = 17,
                                    GearsQuantity = 16,
                                    Price = 356,
                                    Weight = 16,
                                    WheelDiameter = 24,
                                    Mnufacture = "Flint",
                                    IamgeUrl = "http://velo-delo.com.ua/image/cache/data/Optima/Optima%20Hunter-850x515.png",
                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                },
                                    new Bicycle
                                    {
                                        Name = "Flint 26",
                                        FrameSize = 15,
                                        GearsQuantity = 18,
                                        Price = 499,
                                        Weight = 17,
                                        WheelDiameter = 26,
                                        Mnufacture = "Flint",
                                        IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                    },
                                        new Bicycle
                                        {
                                            Name = "Azimut Fara 24",
                                            FrameSize = 15,
                                            GearsQuantity = 1,
                                            Price = 400,
                                            Weight = 15,
                                            WheelDiameter = 24,
                                            Mnufacture = "Azimut",
                                            IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                            Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                        },
                                              new Bicycle
                                              {
                                                  Name = " Discovery Rider",
                                                  FrameSize = 13,
                                                  GearsQuantity = 28,
                                                  Price = 400,
                                                  Weight = 16,
                                                  WheelDiameter = 26,
                                                  Mnufacture = "Azimut",
                                                  IamgeUrl = "http://pngimg.com/uploads/bicycle/bicycle_PNG5372.png",
                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                              },
                                                new Bicycle
                                                {
                                                    Name = "Azimut Fara 27",
                                                    FrameSize = 15,
                                                    GearsQuantity = 16,
                                                    Price = 600,
                                                    Weight = 16,
                                                    WheelDiameter = 27,
                                                    Mnufacture = "Azimut",
                                                    IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                },
                                                    new Bicycle
                                                    {
                                                        Name = "Azimut Blackmount 20",
                                                        FrameSize = 17,
                                                        GearsQuantity = 12,
                                                        Price = 350,
                                                        Weight = 18,
                                                        WheelDiameter = 20,
                                                        Mnufacture = "Azimut",
                                                        IamgeUrl = "https://velobarnaul.ru/upload/glossaryImages/820e35d660e98c20103508f4c8eacd65.png",
                                                        Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                    },
                                                          new Bicycle
                                                          {
                                                              Name = "Azimut Blackmount 24",
                                                              FrameSize = 13,
                                                              GearsQuantity = 1,
                                                              Price = 299,
                                                              Weight = 14,
                                                              WheelDiameter = 24,
                                                              Mnufacture = "Azimut",
                                                              IamgeUrl = "https://velobarnaul.ru/upload/glossaryImages/820e35d660e98c20103508f4c8eacd65.png",
                                                              Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                          },
                                                                new Bicycle
                                                                {
                                                                    Name = "Discovery Passion",
                                                                    FrameSize = 16,
                                                                    GearsQuantity = 24,
                                                                    Price = 600,
                                                                    Weight = 12,
                                                                    WheelDiameter = 22,
                                                                    Mnufacture = "Discovery",
                                                                    IamgeUrl = "https://alfasport.com.ua/Media/shop-8179/AtlanticProtonNX.png",
                                                                    Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                },
                                                                      new Bicycle
                                                                      {
                                                                          Name = "Formula Smart 24",
                                                                          FrameSize = 17,
                                                                          GearsQuantity = 3,
                                                                          Price = 300,
                                                                          Weight = 16,
                                                                          WheelDiameter = 24,
                                                                          Mnufacture = "Formula",
                                                                          IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                          Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                      },
                                                                           new Bicycle
                                                                           {
                                                                               Name = "Formula Smart 26",
                                                                               FrameSize = 17,
                                                                               GearsQuantity = 21,
                                                                               Price = 399,
                                                                               Weight = 18,
                                                                               WheelDiameter = 26,
                                                                               Mnufacture = "Formula",
                                                                               IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                               Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                           },
                                                                              new Bicycle
                                                                              {
                                                                                  Name = "Formula Smart 27",
                                                                                  FrameSize = 20,
                                                                                  GearsQuantity = 34,
                                                                                  Price = 450,
                                                                                  Weight = 120,
                                                                                  WheelDiameter = 27,
                                                                                  Mnufacture = "Formula",
                                                                                  IamgeUrl = "https://titanbike.ua/img/bike-tab.png",
                                                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                              }, new Bicycle
                                                                              {
                                                                                  Name = "Azimut Fara 24",
                                                                                  FrameSize = 15,
                                                                                  GearsQuantity = 1,
                                                                                  Price = 400,
                                                                                  Weight = 15,
                                                                                  WheelDiameter = 24,
                                                                                  Mnufacture = "Azimut",
                                                                                  IamgeUrl = "https://pngimg.com/uploads/bicycle/bicycle_PNG5393.png",
                                                                                  Discripton = @$"In the test, the powerful, fourth generation Bosch 
Performance CX motor was completely impressive, 
which since the latest update now offers a full 85 Nm and 340% pedal assist. 
With four different driving modes from Eco to Turbo, as well as the new eMTB mode,
you always have the right assist mode ready for you when things go steeply uphill again."


                                                                              });


            context.SaveChanges();

            }


        }
    }
}
