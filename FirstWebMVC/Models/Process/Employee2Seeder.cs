using Bogus; // Thêm thư viện Bogus để dùng Faker
using FirstWebMVC.Data;
using FirstWebMVC.Models.Entities;


namespace FirstWebMVC.Models.Process
{
    public class Employee2Seeder
    {
        private readonly ApplicationDbContext _context;

        public Employee2Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedEmployee2s(int n)
        {
            var Employee2s = GenerateEmployee2s(n); // Đổi tên phương thức
            _context.Employee2.AddRange(Employee2s); // Đảm bảo _context.Employee2 tồn tại và là DbSet<Employee2>
            _context.SaveChanges();
        }

        private List<Employee2> GenerateEmployee2s(int n)
        {
            var faker = new Faker<Employee2>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.DateofBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(e => e.Position, f => f.Name.JobTitle())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.HireDate, f => f.Date.Past(10));

            return faker.Generate(n);
        }
    }
}