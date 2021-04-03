#!/bin/bash
GIT_API_KEY=g<your git apikey>
NUGET_API_KEY=<your nuget apikey>
VERSION=1.0.3 #for each release you change csproj with version and update here.

dotnet pack --configuration Release
 cd Framework
dotnet nuget push Hydra.Core.Abstractions/bin/Release/Hydra.Core.Abstractions.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.API/bin/Release/Hydra.Core.API.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Domain/bin/Release/Hydra.Core.Domain.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.EventSourcing/bin/Release/Hydra.Core.EventSourcing.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.gRPC/bin/Release/Hydra.Core.gRPC.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Mediator/bin/Release/Hydra.Core.Mediator.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.MessageBus/bin/Release/Hydra.Core.MessageBus.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Specification/bin/Release/Hydra.Core.Specification.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Validator/bin/Release/Hydra.Core.Validator.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"



dotnet nuget push Hydra.Core.Abstractions/bin/Release/Hydra.Core.Abstractions.$VERSION.nupkg --api-key $NUGET_API_KEY --source https://api.nuget.org/v3/index.json
dotnet nuget push Hydra.Core.API/bin/Release/Hydra.Core.API.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Domain/bin/Release/Hydra.Core.Domain.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.EventSourcing/bin/Release/Hydra.Core.EventSourcing.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.gRPC/bin/Release/Hydra.Core.gRPC.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Mediator/bin/Release/Hydra.Core.Mediator.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.MessageBus/bin/Release/Hydra.Core.MessageBus.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Specification/bin/Release/Hydra.Core.Specification.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Validator/bin/Release/Hydra.Core.Validator.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"