using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string menu = "1-Araba işlemleri \n" +
                          "2-Marka İşlemleri\n" +
                          "3-Renk işlemleri\n" +
                          "4-Müşteri işlemleri\n" +
                          "5-Kiralama işlemleri\n" +
                          "6- Kullanıcı işlemleri\n" +
                          "Cikmak için : 0";
            string carOperations = "1 - Arabaları göster\n" +
                                   "2 - Markalara göre tüm arabaları göster\n" +
                                   "3 - Renkelerine göre tüm arabaları göster\n" +
                                   "4 - Arabaların detaylarını göster\n" +
                                   "5 - Yeni araba ekle\n" +
                                   "6 - Araba sil\n" +
                                   "7 - Araba Güncelle\n";
            string brandOperations = "1 - Markaları göster\n" +
                                     "2 - Yeni Marka Ekle\n" +
                                     "3 - Marka sil\n" +
                                     "4 - Marka Güncelle\n";
            string colorOperations = "1 - Renkleri göster\n" +
                                     "2 - Yeni renk Ekle\n" +
                                     "3 - Rengi sil\n" +
                                     "4 - Renk Güncelle\n";
            string customerOperations = "1 - Müşterileri göster\n" +
                                        "2 - Müşteri Detaylarını göster\n" +
                                        "3 - Yeni Müşteri Ekle\n" +
                                        "4 - Müşteri sil\n" +
                                        "5 - Müşteri Güncelle\n";
            string rentalOperations = "1 - Araçların durumunu göster\n" +
                                      "2 - Araç kirala\n" +
                                      "3 - Kiralamayı sil\n" +
                                      "4 - Kiralamayı güncelle\n";
            string userOperations = "1 - Kullanıcıları listele\n" +
                                    "2 - Kullanıcı ekle\n" +
                                    "3 - Kullanıcı Güncelle\n" +
                                    "4- Kullanıcı sil\n";

            while (true)
            {
                Console.WriteLine(menu);
                int subChoose, choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine(carOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        OperationsOfCar(subChoose);
                        Console.ReadLine();

                        break;
                    case 2:
                        Console.WriteLine(brandOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        OperationsOfBrand(subChoose);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine(colorOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        OperationsOfColor(subChoose);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine(customerOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine(rentalOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine(userOperations);
                        subChoose = int.Parse(Console.ReadLine());
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Geçersiz işlemççç");
                        break;
                }
            }




        }

        private static void OperationsOfColor(int choose)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            List<Color> colors;
            switch (choose)
            {
                case 1:
                    colors = colorManager.GetAll().Data;
                    foreach (var brand in colors)
                    {
                        Console.WriteLine("Renk Id : " + brand.ColorId + " Renk Adı : " + brand.ColorName);
                    }
                    break;
                case 2:
                    Color addedColor= new Color();
                    Console.Write("Renk Adini giriniz : ");
                    addedColor.ColorName = Console.ReadLine();
                    colorManager.AddColor(addedColor);
                    break;
                case 3:
                    Color deletedColor= new Color();
                    colors = colorManager.GetAll().Data;
                    foreach (var color in colors)
                    {
                        Console.WriteLine("Renk Id : " + color.ColorId + " Renk Adı : " + color.ColorName);
                    }
                    Console.Write("Silinecek Renk Id : ");
                    deletedColor.ColorId = int.Parse(Console.ReadLine());
                    colorManager.DeleteColor(deletedColor);
                    break;
                case 4:
                    Color updatedColor = new Color();
                    colors = colorManager.GetAll().Data;
                    foreach (var color in colors)
                    {
                        Console.WriteLine("Renk Id : " + color.ColorId + " Renk Adı : " + color.ColorName);
                    }
                    Console.Write("Güncellenecek Renk id  :  ");
                    updatedColor.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Yeni adını giriniz : ");
                    updatedColor.ColorName = Console.ReadLine();
                    colorManager.UpdateColor(updatedColor);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim !!");
                    break;
            }
        }
        private static void OperationsOfBrand(int choose)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            List<Brand> brands;

            switch (choose)
            {
                case 1:
                    brands = brandManager.GetAll().Data;
                    foreach (var brand in brands)
                    {
                        Console.WriteLine("Marka Id : "+brand.BrandId + " Marka Adı : "+brand.BrandName);
                    }
                    break;
                case 2:
                    Brand addedBrand = new Brand();
                    Console.Write("Marka Adini giriniz : ");
                    addedBrand.BrandName = Console.ReadLine();
                    brandManager.AddBrand(addedBrand);
                    break;
                case 3:
                    Brand deletedBrand = new Brand();
                    brands = brandManager.GetAll().Data;
                    foreach (var brand in brands)
                    {
                        Console.WriteLine("Marka Id : " + brand.BrandId + " Marka Adı : " + brand.BrandName);
                    }
                    Console.Write("Silinecek Markanın Id : ");
                    deletedBrand.BrandId = int.Parse(Console.ReadLine());
                    brandManager.DeleteBrand(deletedBrand);
                    break;
                case 4:
                    Brand updatedBrand = new Brand();
                    brands = brandManager.GetAll().Data;
                    foreach (var brand in brands)
                    {
                        Console.WriteLine("Marka Id : " + brand.BrandId + " Marka Adı : " + brand.BrandName);
                    }
                    Console.Write("Güncellenecek markanınId :  ");
                    updatedBrand.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Yeni adını giriniz : ");
                    updatedBrand.BrandName = Console.ReadLine();
                    brandManager.UpdateBrand(updatedBrand);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim !!");
                    break;
            }

        }

        private static void OperationsOfCar(int choose)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> result;
            switch (choose)
            {
                case 1:
                    result = carManager.GetAll().Data;
                    foreach (var car in result)
                    {
                        Console.WriteLine("Id : " + car.Id + " Araba adi : " + car.CarName + " Model yılı : " + car.ModelYear + " Arac Günlük Fiyatı : " + car.DailyPrice + "Arac Aciklama : " + car.Description);

                    }

                    break;
                case 2:
                    Console.WriteLine("Marka id si giriniz : ");
                    int brand = int.Parse(Console.ReadLine());
                    result = carManager.GetCarsByBrandId(brand).Data;
                    foreach (var car in result)
                    {
                        Console.WriteLine("Id : " + car.Id + " Araba adi : " + car.CarName + " Model yılı : " + car.ModelYear + " Arac Günlük Fiyatı : " + car.DailyPrice + "Arac Aciklama : " + car.Description);

                    }
                    break;
                case 3:
                    Console.WriteLine("Renk id si giriniz : ");
                    int color = int.Parse(Console.ReadLine());
                    result = carManager.GetCarsByColorId(color).Data;
                    foreach (var car in result)
                    {
                        Console.WriteLine("Id : " + car.Id + " Araba adi : " + car.CarName + " Model yılı : " + car.ModelYear + " Arac Günlük Fiyatı : " + car.DailyPrice + "Arac Aciklama : " + car.Description);

                    }
                    break;
                case 4:
                    List<CarDetailDto> details = carManager.GetCarDetails().Data;
                    foreach (var car in details)
                    {
                        Console.WriteLine("Araba adi : " + car.CarName + " Marka Adi : " + car.BrandName + " Rengi : " + car.ColorName + " Günlük fiyat : " + car.DailyPrice);
                    }
                    break;
                case 5:
                    Car addedCar = new Car();
                    Console.Write("Marka Id sini giriniz : ");
                    addedCar.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Renk id sini giriniz : ");
                    addedCar.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Araba adını giriniz :");
                    addedCar.CarName = Console.ReadLine();
                    Console.Write("Model yilini giriniz : ");
                    addedCar.ModelYear = int.Parse(Console.ReadLine());
                    Console.Write("Günlük fiyatını giriniz : ");
                    addedCar.DailyPrice = int.Parse(Console.ReadLine());
                    Console.Write("Arac aciklamasini giriniz : ");
                    addedCar.Description = Console.ReadLine();

                    carManager.AddCar(addedCar);
                    break;
                case 6:
                    Car deletedCar = new Car();
                    result = carManager.GetAll().Data;
                    foreach (var car in result)
                    {
                        Console.WriteLine("Id : " + car.Id + " Araba adi : " + car.CarName + " Model yılı : " + car.ModelYear + " Arac Günlük Fiyatı : " + car.DailyPrice + "Arac Aciklama : " + car.Description);

                    }
                    Console.Write("Silinecek aracın ıd sini giriniz : ");
                    deletedCar.Id = int.Parse(Console.ReadLine());
                    carManager.DeleteCar(deletedCar);
                    break;
                case 7:
                    Car updatedCar = new Car();
                    result = carManager.GetAll().Data;
                    foreach (var car in result)
                    {
                        Console.WriteLine("Id : " + car.Id + " Araba adi : " + car.CarName + " Model yılı : " + car.ModelYear + " Arac Günlük Fiyatı : " + car.DailyPrice + "Arac Aciklama : " + car.Description);

                    }
                    Console.Write("Güncellenecek aracın id sini giriniz");
                    updatedCar.Id = int.Parse(Console.ReadLine());
                    Console.Write("Marka Id sini giriniz : ");
                    updatedCar.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Renk id sini giriniz : ");
                    updatedCar.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Araba adını giriniz :");
                    updatedCar.CarName = Console.ReadLine();
                    Console.Write("Model yilini giriniz : ");
                    updatedCar.ModelYear = int.Parse(Console.ReadLine());
                    Console.Write("Günlük fiyatını giriniz : ");
                    updatedCar.DailyPrice = int.Parse(Console.ReadLine());
                    Console.Write("Arac aciklamasini giriniz : ");
                    updatedCar.Description = Console.ReadLine();

                    carManager.UpdateCar(updatedCar);
                    break;
                default:
                    Console.WriteLine("Hatalı işlem ");
                    break;

            }

        }


    }
}
