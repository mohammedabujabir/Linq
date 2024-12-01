using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Program
    {
        /*
         *  Linq:هن عبارة عن 40 اكستنشن ميثود بديل select in c# لDQL
         * extintion method
         * هذول الاربعين بطبقو على اي اشي IEnumerable
         * 
         * 2 syntax مشان اكتب linq:
         * 1-Fluent syntax :ممكن يطبق على static method
         * extention method وممكن من خلال 
         * 2-query syntax: like sql server style 
         * 
         * 
         * linq execution ways :
         * 1-Deferred execution :رح اشتغل على نسخة الاخيرة من الداتا 
         * 2-Immediate execution:
         * 1-Casting operator
         * 2-Aggregate operator
         * 3-Element operator
         * 
         *local data:
         *في عنل اسلوبين بالشغل لما نربط داتا بيس في سي شارب 
         *1-First Code:هون ما راح اعمل داتا بيس راح اعمل كلاسات وهذول كلاسات يتحولن لجداول في داتا بيس 
         *2-DataBase Code:
         *
         */
        static void Main(string[] args)
        {
            // extintion method 
            int x = 10;
            int result = x.IncOne();//ما بقدر استخدمها هيك لانو مش اكستنشن ميثود ننعملهااعملنا كلاس عادي حطينا في ميثود ولازم نحط this وstatic للكلاس  زي ما هو موضح بصير اكستنشن ميثود وعادي نستخدمها  
            Console.WriteLine(result);

            Console.WriteLine("----------LinQ---------");

            List<int> numbers = new List<int >() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //بدنا نعمل ليست جديدة فيها الارقام الاكبر من خمسة 
            //where هاي بتوخذ فنشكن من جوافي سي شارب ما بقدر ابعث فنكشن لفنكشن بزبط من خلال
            //delegate او خلص من خلال lambda expretion 
            //Fluent syntax: - extintion method 
            List<int> Result = numbers.Where(item => item >= 5).ToList();

            foreach (int item in Result) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //Fluent syntax: - static method 
            List<int>OddNumbers=Enumerable.Where(numbers, item => item % 2==1).ToList();
            foreach (int item in OddNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //query syntax
            var oddnumbers=from n in  numbers where n%2==1 select n;
            foreach (int item in oddnumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //Deferred execution :رح اشتغل على نسخة الاخيرة من الداتا
            //فهون راح يعمل ليست ويضيف عليها 11ولما ينادي لوب بروح بنفذ لينكيو
            var res = numbers.Where(number => number % 2 == 1);
            numbers.Add(11);
            foreach (int item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //Immediate execution:
            // - Casting operator
            //هاي لما عمل كاستنك ب بطل يشتغل على الحالية زي فوق بصير ع قديمة على البيانات الحالية 
            var Res = numbers.Where(number => number % 2 == 1).ToList();
            numbers.Add(12);
            foreach (int item in Res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //filteration operator[where]
            List<Product>p= new List<Product>()
            {
               new Product { Id = 1, Name = "Smartphone", Price = 999.99m,Category="phone" },
               new Product { Id = 2, Name = "Laptop", Price = 1500.50m ,Category="Computer" },
               new Product { Id = 3, Name = "Headphones", Price = 199.99m,Category="Computer"},
               new Product { Id = 4, Name = "Tablet", Price = 499.99m ,Category="phone"  }
            };
            Console.WriteLine(p[0].Price);
            //جيب كل المنتجات السعر الهم اكبر من 900
            var products = p.Where(item => item.Price > 900);
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine("------------------");
            //Select * from product 
            //var product = p.ToList();
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("------------------");
            ////Select Name from product 
            //var product = p.Select(item => item.Name);
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("------------------");
            ////Select Name from product  where price > 500
            //var product = p.Where(item=>item.Price>500).Select(item => item.Name);
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("------------------");
            ////Select * from product  واتحكم بشكل البيانات كيف يرجع 
            //var product = p.Select(item => $"Name: {item.Name}...Price:{item.Price}");
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("------------------");
            //ordering operator[OrderBy]
            //select * from product order by price
            //var product = p.OrderBy(item => item.Price);//دفولت برتب تصاعدي من صغير للكبير
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("------------------");
            //select * from product order by price Desc
            //var product = p.OrderByDescending(item => item.Price);//نرتب تنازلي من كبير لصغير 
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item);
            //}

            //element operator
            //بدي انا المنتج الاول فقط 
            //Console.WriteLine("-------------");
            //var product = p.First();
            //Console.WriteLine(product);

            //بدي انا اخر منتج 
            //Console.WriteLine("-------------");
            //var product = p.Last();
            //Console.WriteLine(product);

            //Console.WriteLine("---------------------------");
            //List<Customer> Customers = new List<Customer>();
            //var customer = Customers.First();
            //Console.WriteLine(customer);//run time error fitst and last اذا ما تنفذو بضرب اكسبشن ايرور

            //Console.WriteLine("---------------------------");
            //List<Customer> Customers = new List<Customer>();
            //var customer = Customers.FirstOrDefault();//اذا ما في برجع دفولت ودفولت هو null 
            //Console.WriteLine((customer?.Name ??"not found"));

            //Console.WriteLine("---------------------------");
            //List<Customer> Customers = new List<Customer>();
            //var customer = Customers.FirstOrDefault(new Customer() { Name = "Test" });//اعطي دفولت انا 
            //Console.WriteLine(customer.Name);

            //Console.WriteLine("---------------------------");
            //بدنا اول منتج بلاكي سعرو اكبر من 1000
            //var product = p.FirstOrDefault(item => item.Price > 1000);
            //Console.WriteLine(product);

            //Console.WriteLine("---------------------------");
            //ElementAt اعطيني العنصر الموجود بالاندكس رقم 2
            //var product = p.ElementAt(2);
            //Console.WriteLine(product);

            //Console.WriteLine("---------------------------");
            //var product = p.ElementAtOrDefault(20);//اذا مش موجودبعطي ايرور بس هيك لاء 
            //Console.WriteLine(product);


            //single اذا بدي اتاكد كن جدول اذا في عنصر واحد اذا في عنصر واحد بدي اطبعو اذا لع ما بدي اطبعو 
            //Fluent syntax هاي بتشتغل مع هاذ بس 
            // var product = p.Single();
            // Console.WriteLine(product);//راح يطلع انو في اكثر من عنصر واذا فش راح يطلع انو فش عناصر 
            //اذا في بس واحد بطبعو 

            //Console.WriteLine("---------------------------");
            //var product = p.SingleOrDefault(p=>p.50);//بترجع null
            //Console.WriteLine(product);


            //aggregate operators
            //Console.WriteLine("---------------------------");
            //var product = p.Count();
            //var product = p.Where(item => item.Price > 500).Count();
            //var product = p.Count(item => item.Price > 500);
            //var product = p.Max(item => item.Price > 500);//return true
            // var product=p.Max(item => item.Price);//return the max value 1500.50
            //var product = p.MaxBy(item => item.Price);//return all information about max 
            // var product=p.Min(item => item.Price);///return the min value 199
            // var product=p.MinBy(item => item.Price)//return all information about min
            // var product=p.Sum(item=> item.Price);//return the sum of price products
            // var product = p.Average(item => item.Price);//return the avg of price products
            //Console.WriteLine(product);

            //Quantifier operations
            // Console.WriteLine("---------------------------");
            // Console.WriteLine(p.Any());//راح ترجع ترو اذا يوجد عنصر واحد على الاقل 
            //الفرق بينها وبين single هون بترجع ترو اذا في عنصر واحد ع الاقل 
            //single بترجع عنصر واحد بس اذا في واحد بس فش غيرو 
            //Console.WriteLine(p.Any(item=>item.Price>1000));//هل يوجد عندي عنصر واحد عالاقل اكبر من الف بترجع ترو 
            //Console.WriteLine(p.All(item=>item.Price>1000));//هل كل العناصر عندي اكبر من 1000 راح ترجع فولس
            //any عنصر واحد ع الاقل يحقق الشرط 
            //all لازم كلهم يحققو الشرط 

            //grouping 
            // Console.WriteLine("---------------------------");
            //بدنا نرتب المنتجات حسب الكاتيجوري
            //var product = p.GroupBy(item => item.Category);
            //foreach(var item in product)
            //{
            //    Console.WriteLine(item.Key);//key بتجيب اسم كاتيجوري 
            //    //طيب انا بدي المنتجات الي داخل هاي الكاتيجوري هون برجع مجموعات اينيرابيل فبدنا كمان لوب
            //    foreach(var item2 in item)
            //    {
            //        Console.WriteLine(item2.Name);
            //    }
            //}

            //بدنا نعرض الكاتيجوري الي فيها اكثر اويساوي2 منتجات 
            //where هون بدل having 
            //Console.WriteLine("---------------------------");
            //var product = p.GroupBy(item => item.Category).Where(item=>item.Count()>=2);
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item.Key);

            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine(item2.Name);
            //    }
            //}



            //Partitioning data
            Console.WriteLine("---------------------------");

            //بدي اول منتجين
            //var product = p.Take(2).ToList();//بجيب اول ثنين وبحطهم باليست

            //foreach(var item in product)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //بدي اعلى سعر لمنتجين 
            //var product=p.OrderByDescending(item=>item.Price).Take(2).ToList();
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //لو بدي اخر منتجين 
            //var product = p.OrderByDescending(item => item.Price).TakeLast(2).ToList();
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //بدي اول منتجين ما اعدا اول واحد 
            //يعني الثاني والثالث

            //var product = p.Skip(1).Take(2).ToList();
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //بدي استثني اخر واحد 
            //var product = p.SkipLast(1).Take(2).ToList();
            //foreach (var item in product)
            //{
            //    Console.WriteLine(item.Name);
            //}



        }
    }
}
