namespace FoodStop_DB
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Scaffold-DbContext 'Server=.;Database=FoodStopV2;Trusted_Connection=True;TrustServerCertificate=True' Microsoft.EntityFrameworkCore.SqlServer


            Branch branchOne = new Branch()
            {
                Name = "Food Cart",
                Location = "Salem Update",
                Phone = 0123456789
            };

            using(var context = new FoodStopV2Context())
            {
                context.Add(branchOne);
                context.SaveChanges();
            }
        }
    }
}