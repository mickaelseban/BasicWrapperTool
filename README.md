# BasicWrapperTool

 [![Build Status](https://img.shields.io/appveyor/ci/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
 [![Unit Tests](https://img.shields.io/appveyor/tests/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
 [![NuGet Badge](https://buildstats.info/nuget/BasicWrapperTool)](https://www.nuget.org/packages/BasicWrapperTool/)
 [![Sonarcloud Status](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=alert_status)](https://sonarcloud.io/dashboard?id=mickaelseban_BasicWrapperTool) 
 [![SonarCloud Coverage](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=coverage)](https://sonarcloud.io/component_measures/metric/coverage/list?id=mickaelseban_BasicWrapperTool)
 [![SonarCloud Bugs](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=bugs)](https://sonarcloud.io/component_measures/metric/reliability_rating/list?id=mickaelseban_BasicWrapperTool)
 [![SonarCloud Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=vulnerabilities)](https://sonarcloud.io/component_measures/metric/security_rating/list?id=mickaelseban_BasicWrapperTool)

Example:
```C#
    public class Example
    {
        public Result<int> DoSomeOperation(Maybe<string> input)
        {
            return ResultBuilder<int, string>
                .Create(input, "input string cannot be null")
                .WithNonNullValue(() => Convert.ToInt32(input.Value))
                .WithMessage("Cannot convert input string into integer")
                .Build();
        }
    }
