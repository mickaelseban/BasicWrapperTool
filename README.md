# BasicWrapperTool

 [![Build Status](https://img.shields.io/appveyor/ci/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
 [![Unit Tests](https://img.shields.io/appveyor/tests/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
 [![NuGet Badge](https://buildstats.info/nuget/BasicWrapperTool)](https://www.nuget.org/packages/BasicWrapperTool/)
 [![Sonarcloud Status](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=alert_status)](https://sonarcloud.io/dashboard?id=mickaelseban_BasicWrapperTool) 
 [![SonarCloud Coverage](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=coverage)](https://sonarcloud.io/component_measures/metric/coverage/list?id=mickaelseban_BasicWrapperTool)
 [![SonarCloud Bugs](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=bugs)](https://sonarcloud.io/component_measures/metric/reliability_rating/list?id=mickaelseban_BasicWrapperTool)
 [![SonarCloud Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=vulnerabilities)](https://sonarcloud.io/component_measures/metric/security_rating/list?id=mickaelseban_BasicWrapperTool)


BasicWrapperTool contains to kinds of wrappers/containers: Maybe and Result.

Maybe<T> - Intent to represents an input value (argument) of a reference type that might or might not exist, might not be a null reference. Usage benefits: Method signature honest, avoid null-checks and mitigates 
[the billion-dollar mistake](https://en.wikipedia.org/wiki/Tony_Hoare) (NullReferenceExceptions being thrown)

Result - Intent to represents a return of a method with operation status

Result<T> - Intent to represents a return of a method with the outcome value and operation status Usage benefits: Method signature honest, avoids null-checks, follows the [Notification Pattern](https://martinfowler.com/eaaDev/Notification.html), follows the CQS design principle.
