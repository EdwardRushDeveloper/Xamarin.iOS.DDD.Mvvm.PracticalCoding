#MySpectrum Example Application (Xamarin – Practical Coding Test)

The MySpectrum Example Application by Edward Rush.




|Project Name|Project Description|
|-----|-----|
|MySpectrum|Example application implementing Domain Driven Design concepts introduced and explained by Eric Evans in his book Domain Driven Design - Tackling complexity in the Heart of Software. This example also using MVVM implemented using MvvmLight|



[![DDD](ddd.ericevans.jpeg)](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215/ref=asc_df_0321125215/?tag=hyprod-20&linkCode=df0&hvadid=312118197030&hvpos=1o1&hvnetw=g&hvrand=11296038046622538557&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9009924&hvtargid=pla-449269547899&psc=1)

[MvvmLight on GitHub](https://github.com/lbugnion/mvvmlight)

See explanation of all layers below.


|Project Name|Project Description|
|-----|-----|
|ApplicationServices|Main Application services for ViewModels, and Gateways. This is code potentially shared and used for the iOS and the Android compiled Applications. This is where the bulk of code occurs with communication proxied through from the UI to DomainServices. Additionally, this is where the  Dependency Injection System would be loaded with Object References for sharing between the UI, Application Services and Domain Service.|
|Domain|Entities, Value Objects, Domain Events, Aggregates. This is code shared for the iOS and Android compiled Applications. This is the Center of the entire Application should have no dependencies from on higher levels. There is a Dependency on the NewtonSoft JSON Engine so Objects can be decorated for Serialization.|
|DomainServices|Repositories, Factories, Domain Services. This is C# code shared for the iOS and Android compiled Applications. This Project dependencies should be limited to Database, File and Serialization and Deserialization operations.|
|iOS|iOS Platform Project where the .app is generated. This UI Layer will exist at this level|
|UI|We do not have a UI project specific for this Test Application as the UI Level will reside in the iOS Project.|


![Project Relationship Diagram](DomainDrivenDesignOnion.png "Project Relationship Diagram") 

