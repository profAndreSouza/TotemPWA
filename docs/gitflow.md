# Git Flow

## Inicializar o fluxo do Git Flow
```sh
git flow init
```

## Trabalhando com branches de feature
### Criar uma nova branch de feature
```sh
git flow feature start base_app
```

### Finalizar uma branch de feature
```sh
git flow feature finish base_app
```

## Criar um novo projeto Dotnet MVC
```sh
dotnet new mvc -o TotemPWA
```

## Sincronizar a branch develop com o repositório remoto
```sh
git add .
git commit -m "Base App" -m "Created base app in dotnet"
git push --set-upstream origin develop
```

## Criar e finalizar uma Release
### Criar uma Release
```sh
git flow release start v0.1
```

### Finalizar a Release
```sh
git flow release finish v0.1
```
> Ao finalizar a release, é obrigatório descrever as implementações daquela release. Após escrever, aperte `ctrl + C` e digite `:wq` e pressione `Enter`.

## Publicar no repositório
```sh
git push origin master develop --tags
```

## Outros comandos úteis
### Excluir a branch feature do repositório remoto
```sh
git push origin --delete feature/minha-feature
```

### Atualizar o repositório local após a exclusão da branch remota
```sh
git fetch --prune
```