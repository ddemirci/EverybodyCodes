# EverybodyCodes
The solution contains five projects. .NET 6 was used.
The second and the third parts are completed in the requested timebox.

# To start the application
1) EverybodyCodes.WebAPI and EverybodyCodes.WebApp should be started respectively. WebAPI project initalizes an in-memory database that is filled from **EverybodyCodes/EverybodyCodes.WebAPI/DataSource/cameras-defb.csv**
2) EverybodyCodes.WebAPI has one endpoint which returns the list of the camera information.
3) EverybodyCodes.WebApp displays retrieved cameras in the map which is provided by [Leaflet JavaScript library](https://leafletjs.com/examples/quick-start/) with the map pictures via [MapBox](https://www.mapbox.com/studio/account/tokens/)
4) When user clicks a camera resides in the map, an alert box appears and the related text turns into red.
