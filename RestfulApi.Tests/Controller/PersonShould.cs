using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using RestfulApi.Business.Implementations;
using RestfulApi.Business.Interfaces;
using RestfulApi.Controllers;
using Xunit;

namespace RestfulApi.Tests.Controller
{
    public class PersonShould
    {
        private readonly IPersonBusiness _personBusiness;
        private readonly PersonController _personController;

        public PersonShould()
        {
            _personBusiness = Substitute.For<IPersonBusiness>();
            _personController = new PersonController(_personBusiness);
        }

        [Fact]
        public void GetAllPersons_IsNotNull()
        {
            var sut = _personController.GetAllPersons();

            Assert.NotNull(sut);
        }
    }
}
