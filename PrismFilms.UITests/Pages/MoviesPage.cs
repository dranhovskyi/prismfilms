using System;
using System.ComponentModel.Design;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PrismFilms.UITests.Pages
{
    public class MoviesPage : BasePage
    {
        readonly Query firstListItem;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("moviesList"),
            iOS = x => x.Marked("moviesList")
        };

        public MoviesPage()
        {
            firstListItem = x => x.Marked("Life of Brian");

            if (OnAndroid)
            {
            }

            if (OniOS)
            {
            }
        }

        public void SelectFirstItem()
        {
            app.WaitForElement(firstListItem);
            app.Tap(firstListItem);
        }
    }
}
