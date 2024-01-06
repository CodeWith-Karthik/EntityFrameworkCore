
using FoodStop.Data;
using FoodStop.Models;

namespace FoodStop
{
    class Program
    {
        public static void Main(string[] args)
        {
            Branch branchOne = new Branch()
            {
                Id = 2,
                Name = "Food Cart",
                Location = "Salem Update",
                Phone = 0123456789
            };

            using(var context = new ApplicationDbContext())
            {
                //Create
                //context.Branch.Add(branch);
                //context.SaveChanges();
                //Console.WriteLine("Record Created");

                //GET
                //var branches = context.Branch.ToList();

                //foreach (var branch in branches)
                //{
                //    Console.WriteLine($"Name:{branch.Name},Location:{branch.Location},Phone No:{branch.Phone}");
                //}

                //Single
                //var branchData = context.Branch.FirstOrDefault(x => x.Id == 2);

                //Update
                //context.Branch.Update(branchOne);
                //context.SaveChanges();  

                //Delete
                //context.Branch.Remove(branchOne);
                //context.SaveChanges();

            }

            Console.ReadKey();
        }
    }
}


