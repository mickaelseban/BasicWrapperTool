# BasicWrapperTool

 [![Build Status](https://img.shields.io/appveyor/ci/mickaelseban/designpatterns/master.svg)](https://ci.appveyor.com/project/mickaelseban/designpatterns)
 [![Unit Tests](https://img.shields.io/appveyor/tests/mickaelseban/designpatterns/master.svg)](https://ci.appveyor.com/project/mickaelseban/designpatterns)
 [![Sonarcloud Status](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_DesignPatterns&metric=alert_status)](https://sonarcloud.io/dashboard?id=mickaelseban_DesignPatterns) 
 [![SonarCloud Coverage](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_DesignPatterns&metric=coverage)](https://sonarcloud.io/component_measures/metric/coverage/list?id=mickaelseban_DesignPatterns)
 [![SonarCloud Bugs](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_DesignPatterns&metric=bugs)](https://sonarcloud.io/component_measures/metric/reliability_rating/list?id=mickaelseban_DesignPatterns)
 [![SonarCloud Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_DesignPatterns&metric=vulnerabilities)](https://sonarcloud.io/component_measures/metric/security_rating/list?id=mickaelseban_DesignPatterns)

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
