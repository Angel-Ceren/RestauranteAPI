using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Context;
using RestauranteAPI.Mappings;
using RestauranteAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.UnitTest
{
    public class DetallePedidoTest
    {
        private readonly DetallePedidoRepository _detallePedidoRepository;
        public DetallePedidoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source = DESKTOP-MQ3SAEG; Initial Catalog=ControlProductos; Integrated Security = True; Trust Server Certificate = True;").Options;

            var dbContext = new ApplicationDbContext(options);

            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            var mapper = configurations.CreateMapper();

            _detallePedidoRepository = new DetallePedidoRepository(dbContext, mapper);
        }
    }
}
