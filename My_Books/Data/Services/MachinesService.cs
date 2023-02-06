using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System;

namespace My_Books.Data.Services
{
    public class MachinesService
    {
        private AppDbContext _context;
        public MachinesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMachine(MachineVM machine)
        {
            var _machine = new Machine()
            {
                Name = machine.Name,
                Units = machine.Units
            };
            _context.Machines.Add(_machine);
            _context.SaveChanges();
        }

    }
}
