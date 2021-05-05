#!/bin/bash
GIT_SOURCE="https://nuget.pkg.github.com/alexandreyembo/index.json"
GIT_API_KEY="your git key"

NUGET_SOURCE="https://api.nuget.org/v3/index.json"
NUGET_API_KEY="your nuget key"

VERSION=1.0.0-beta-$(date +'%y%m%d').2 #for each release you change csproj with version and update here.


# nuget delete Hydra.Core.Abstractions.1.0.1 -Source "https://api.nuget.org/v3/index.json" -apikey $NUGET_API_KEY


dotnet pack --configuration -c Release /p:Version=$VERSION
cd Framework

# dotnet nuget delete Hydra.Core.Abstractions $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Validator $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Mediator $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Domain $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Data $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.EventSourcing $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.API $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Data.Query $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.gRPC $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.MessageBus $VERSION --source $GIT_SOURCE--api-key $GIT_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Specification $VERSION --source $GIT_SOURCE --api-key $GIT_API_KEY --non-interactive

# dotnet nuget delete Hydra.Core.Abstractions $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Validator $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Mediator $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Domain $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Data $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.EventSourcing $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.API $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# # dotnet nuget delete Hydra.Core.Data.Query $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.gRPC $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.MessageBus $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive
# dotnet nuget delete Hydra.Core.Specification $VERSION --source $NUGET_SOURCE --api-key $NUGET_API_KEY --non-interactive


dotnet nuget push Hydra.Core.Abstractions/bin/Release/Hydra.Core.Abstractions.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Validator/bin/Release/Hydra.Core.Validator.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"

dotnet nuget push Hydra.Core.Mediator/bin/Release/Hydra.Core.Mediator.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Domain/bin/Release/Hydra.Core.Domain.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.EventSourcing/bin/Release/Hydra.Core.EventSourcing.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.API/bin/Release/Hydra.Core.API.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.Query.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.gRPC/bin/Release/Hydra.Core.gRPC.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.MessageBus/bin/Release/Hydra.Core.MessageBus.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"
dotnet nuget push Hydra.Core.Specification/bin/Release/Hydra.Core.Specification.$VERSION.nupkg --api-key $GIT_API_KEY --source "https://nuget.pkg.github.com/alexandreyembo/index.json"

# nuget
dotnet nuget push Hydra.Core.Abstractions/bin/Release/Hydra.Core.Abstractions.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json" 
dotnet nuget push Hydra.Core.Validator/bin/Release/Hydra.Core.Validator.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Mediator/bin/Release/Hydra.Core.Mediator.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Domain/bin/Release/Hydra.Core.Domain.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.EventSourcing/bin/Release/Hydra.Core.EventSourcing.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.API/bin/Release/Hydra.Core.API.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Data/bin/Release/Hydra.Core.Data.Query.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.gRPC/bin/Release/Hydra.Core.gRPC.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.MessageBus/bin/Release/Hydra.Core.MessageBus.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
dotnet nuget push Hydra.Core.Specification/bin/Release/Hydra.Core.Specification.$VERSION.nupkg --api-key $NUGET_API_KEY --source "https://api.nuget.org/v3/index.json"
cd ..