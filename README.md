# BasicWrapperTool

[![Build Status](https://img.shields.io/appveyor/ci/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
[![Unit Tests](https://img.shields.io/appveyor/tests/mickaelseban/basicwrappertool/master.svg)](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
[![NuGet Badge](https://buildstats.info/nuget/BasicWrapperTool)](https://www.nuget.org/packages/BasicWrapperTool/)
[![Sonarcloud Status](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=alert_status)](https://sonarcloud.io/dashboard?id=mickaelseban_BasicWrapperTool)
[![SonarCloud Coverage](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=coverage)](https://sonarcloud.io/component_measures/metric/coverage/list?id=mickaelseban_BasicWrapperTool)
[![SonarCloud Bugs](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=bugs)](https://sonarcloud.io/component_measures/metric/reliability_rating/list?id=mickaelseban_BasicWrapperTool)
[![SonarCloud Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mickaelseban_BasicWrapperTool&metric=vulnerabilities)](https://sonarcloud.io/component_measures/metric/security_rating/list?id=mickaelseban_BasicWrapperTool)

## Overview

BasicWrapperTool provides two primary types of wrappers/containers: `Maybe` and `Result`.

### Maybe\<T>

The `Maybe<T>` type is designed to represent an input value (argument) of a reference type that might or might not exist, potentially avoiding a null reference. 

**Benefits:**
- Honest method signatures
- Avoids null-checks
- Mitigates [the billion-dollar mistake](https://en.wikipedia.org/wiki/Tony_Hoare) (NullReferenceExceptions)

### Result

The `Result` type is designed to represent the return value of a method along with its operation status.

#### Result

Represents the operation status of a method.

#### Result\<T>

Represents both the operation status and the outcome value of a method.

**Benefits:**
- Honest method signatures
- Avoids null-checks
- Follows the [Notification Pattern](https://martinfowler.com/eaaDev/Notification.html)
- Adheres to the CQS (Command Query Separation) design principle


## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.

## Links

- [Build Status](https://ci.appveyor.com/project/mickaelseban/basicwrappertool)
- [NuGet Package](https://www.nuget.org/packages/BasicWrapperTool/)
- [SonarCloud Dashboard](https://sonarcloud.io/dashboard?id=mickaelseban_BasicWrapperTool)
