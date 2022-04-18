namespace SWAP42.Services.Test
{
    using Moq;
    using NUnit.Framework;
    using SWAP42.Core.Contracts.Helpers;
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Tests
    {
        private Mock<IBikeRepository> _mockRepository;
        private Mock<IConfigReader> _mockConfigReader;

        private BikeService _bikeSerivice;

        [SetUp]
        public void Setup()
        {
            this._mockRepository = new Mock<IBikeRepository>();
            this._mockConfigReader = new Mock<IConfigReader>();

            this._bikeSerivice = new BikeService(this._mockRepository.Object, this._mockConfigReader.Object);
        }

        [Test]
        public void GetBikeTheftsByLocationTest()
        {
            var bikeSearchResult = new BikeSearchResult()
            {
                Bikes = new List<Bike>()
                {
                    new Bike() { Id = 1, IsStolen = false },
                    new Bike() { Id = 2, IsStolen = true },
                    new Bike() { Id = 3, IsStolen = false },
                    new Bike() { Id = 4, IsStolen = true },
                    new Bike() { Id = 5, IsStolen = false },
                }
            };

            this._mockRepository.Setup(p => p.GetBikes<BikeSearchResult>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(bikeSearchResult));

            var result = this._bikeSerivice.GetBikeTheftsByLocation("Amsterdam, The Netherlands").Result;

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.IsTrue(result.Any(x => x.Id == 2));
            Assert.IsTrue(result.Any(x => x.Id == 4));
        }

        [Test]
        public void GetBikeTheftCountByLocationTest()
        {
            var bikeSearchCountResult = new BikeSearchCountResult()
            {
                Location = string.Empty,
                Proximity = 131
            };

            this._mockRepository.Setup(p => p.GetBikeCount<BikeSearchCountResult>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(bikeSearchCountResult));

            var result = this._bikeSerivice.GetBikeTheftCountByLocation("Amsterdam, The Netherlands").Result;

            Assert.AreEqual("Amsterdam, The Netherlands", result.Location);
            Assert.AreEqual(131, result.Proximity);
        }
    }
}