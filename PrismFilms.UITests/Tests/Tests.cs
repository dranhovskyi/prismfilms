using System;
using NUnit.Framework;
using PrismFilms.UITests.Pages;
using Xamarin.UITest;

namespace PrismFilms.UITests.Tests
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
                Assert.Ignore("Local only");

            app.Repl();
        }

        [Test]
        public void OpenMoviesDetailPageAnGoBack()
        {
            new MoviesPage()
                .SelectFirstItem();            
           
            app.Back();
        }
    }
}
