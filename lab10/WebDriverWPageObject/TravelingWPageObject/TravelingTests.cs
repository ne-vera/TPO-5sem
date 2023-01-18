
using PageObjects;
using PageObjects.Traveling;

namespace TravelingWPageObject
{
    public class Tests : BaseTest
    {
        [Test]
        public void SearchAgencyByName()
        {
            StartTravelingPage startTraveling = new(driver);

            startTraveling.ClickBtnAgencies();

            AgenciesTravelingPage agenciesTraveling = new(driver);
            agenciesTraveling.SendTextToQuery();

            agenciesTraveling.ClickSearchHotels();

            Assert.That(agenciesTraveling.CheckAgenciesSearchResults());
        }

        [Test]
        public void SearchVisasByGoal()
        {
            StartTravelingPage startTraveling = new(driver);

            startTraveling.ClickBtnVisas();

            VisasTravelingPage visasTraveling= new(driver);
            visasTraveling.SetVisaFilters();
            visasTraveling.ClickBtnSearchVisa();

            Assert.That(visasTraveling.CheckVisaSearchResults());
        }
    }
}