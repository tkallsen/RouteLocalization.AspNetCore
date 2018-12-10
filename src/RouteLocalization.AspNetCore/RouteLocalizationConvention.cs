namespace RouteLocalization.AspNetCore
{
	using Microsoft.AspNetCore.Mvc.ApplicationModels;
	using Microsoft.Extensions.Options;

	public class RouteLocalizationConvention : IApplicationModelConvention
	{
		public RouteLocalizationConvention(RouteTranslator routeTranslator, IOptions<RouteTranslatorOptions> routeTranslatorOptions)
		{
			RouteTranslator = routeTranslator;
			RouteTranslatorOptions = routeTranslatorOptions.Value;
		}

		public RouteTranslatorOptions RouteTranslatorOptions { get; set; }

		public RouteTranslator RouteTranslator { get; set; }

		public void Apply(ApplicationModel application)
		{
			System.Diagnostics.Debug.WriteLine($"RouteLocalizationConvention.Apply called at {System.DateTime.Now} {System.Guid.NewGuid()}");

			RouteTranslatorOptions.RouteTranslatorAction(RouteTranslator);
			RouteTranslator.Apply(application);
		}
	}
}