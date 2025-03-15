## プロジェクトの作成方法

### 基本的な作成方法

```
 dotnet new console -n Sample101
```

new 第二引数にどのようなアプリケーションを作成するかを記述する

```
$ dotnet new --help

Description:
  .NET CLI のテンプレート インスタンス化コマンド。

使用法:
  dotnet new [<template-short-name> [<template-args>...]] [options]
  dotnet new [command] [options]

引数:
  <template-short-name>  作成するテンプレートの短い名前。
  <template-args>        使用するテンプレート固有のオプション。

オプション:
  -o, --output <output>    生成された出力を配置する場所。
  -n, --name <name>        作成される出力の名前です。名前を指定しない場合は、出力ディレクトリの名前が使用されます。
  --dry-run                指定されたコマンドラインがテンプレートを実行した場合に発生する結果の概要を表示します。
  --force                  既存のファイルが変更された場合でも、コンテンツを強制的に生成します。
  --no-update-check        テンプレートをインスタンス化する場合に、テンプレート パッケージの更新の確認を無効にします。
  --project <project>      コンテキストの評価に使用する必要があるプロジェクトです。
  -v, --verbosity <LEVEL>  詳細レベルを設定します。許可されている値: q[uiet]、m[inimal]、n[ormal]、diag[nostic]。 [default: normal]
  -d, --diagnostics        診断出力を有効にします。
  -?, -h, --help           コマンド ラインのヘルプを表示します。

コマンド:
  create <template-short-name> <template-args>  指定された短い名前のテンプレートをインスタンス化します。'dotnet new <template name>' のエイリアス。
  install <package>                             テンプレート パッケージをインストールします。
  uninstall <package>                           テンプレート パッケージをアンインストールします。
  update                                        更新のために現在インストールされているテンプレート パッケージを確認し、更新プログラムをインストールしてください。
  search <template-name>                        NuGet.org 上のテンプレートを検索します。
  list <template-name>                          指定されたテンプレート名を含むテンプレートを一覧表示します。名前を指定しない場合、すべてのテンプレートが一覧表示されます。
  details <package-identifier>                  指定されたテンプレート パッケージの詳細情報を提供します。
                                                      このコマンドは、パッケージがローカルにインストールされているかどうかを確認します。パッケージが見つからなかった場合は、構成済みの NuGet フィードが検索されます。
```

### 古いバージョンで作成する方法

```
$ dotnet new console --use-program-main -n Sample101-OldStyle
```

`--use-program-main`を付ける事で、Program.cs で作成されたアプリが、
古いバージョンの記述になる。

#### --use-program-main 無し(新しいバージョン)

```Sample101/Program.cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

#### --use-program-main 有り(古いバージョン)

```Sample101-OldStyle/Program.cs
namespace Sample101_OldStyle;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("HelloWorld.");
        // Console.WriteLine("Hello, World!");
    }
}
```

## コメントアウト

javascript と同じく // でコメントアウト

## 文字列の扱いについて

ダブルクオーテーションで記述する必要有り

OK `Console.WriteLine("HelloWorld.");`
NG `Console.WriteLine('HelloWorld.');` // : error CS1012: 文字リテラルに文字が多すぎます

## エディタでの実行方法

### 単発で実行する場合

```
$ dotnet run
```

### 保存時に自動的に実行する(nodemon のような)

```
$ dotnet watch run
```

## 変数宣言

変数宣言は `type 変数名 = 値;` と記述をする
※ 同一 type であれば複数の変数も宣言可能
`type 変数名1 = 値, 変数名2 = 値, 変数名3 = 値;`

type の種類一例

-   int 整数型
-   double 小数点
-   string 文字型

```
int number;
int numberVal = 777;
double doubleNumber = 777.777;
string name = "Suzuki Taro"

同一typeであれば複数変数を宣言可能

string firstName="鈴木", lastName="太郎";
```

## コードフォーマット関連

以下 URL に記載しているサンプルフォーマットテンプレート
https://tech-blog.cloud-config.jp/2020-12-18-visual-studio-code-for-csharp-development/

~/.omnisharp/omnisharp.json に記述するか、プロジェクトのルートに記述する(.omnisharp/omnisharp.json)

```omnisharp.json
{
    "FormattingOptions": {
        "EnableEditorConfigSupport": false,
        "NewLine": "\n",
        "UseTabs": false,
        "TabSize": 2,
        "IndentationSize": 2,
        "SpacingAfterMethodDeclarationName": false,
        "SpaceWithinMethodDeclarationParenthesis": false,
        "SpaceBetweenEmptyMethodDeclarationParentheses": false,
        "SpaceAfterMethodCallName": false,
        "SpaceWithinMethodCallParentheses": false,
        "SpaceBetweenEmptyMethodCallParentheses": false,
        "SpaceAfterControlFlowStatementKeyword": true,
        "SpaceWithinExpressionParentheses": false,
        "SpaceWithinCastParentheses": false,
        "SpaceWithinOtherParentheses": false,
        "SpaceAfterCast": false,
        "SpacesIgnoreAroundVariableDeclaration": false,
        "SpaceBeforeOpenSquareBracket": false,
        "SpaceBetweenEmptySquareBrackets": false,
        "SpaceWithinSquareBrackets": false,
        "SpaceAfterColonInBaseTypeDeclaration": true,
        "SpaceAfterComma": true,
        "SpaceAfterDot": false,
        "SpaceAfterSemicolonsInForStatement": true,
        "SpaceBeforeColonInBaseTypeDeclaration": true,
        "SpaceBeforeComma": false,
        "SpaceBeforeDot": false,
        "SpaceBeforeSemicolonsInForStatement": false,
        "SpacingAroundBinaryOperator": "single",
        "IndentBraces": false,
        "IndentBlock": true,
        "IndentSwitchSection": true,
        "IndentSwitchCaseSection": true,
        "IndentSwitchCaseSectionWhenBlock": true,
        "LabelPositioning": "oneLess",
        "WrappingPreserveSingleLine": true,
        "WrappingKeepStatementsOnSingleLine": true,
        "NewLinesForBracesInTypes": true,
        "NewLinesForBracesInMethods": true,
        "NewLinesForBracesInProperties": true,
        "NewLinesForBracesInAccessors": true,
        "NewLinesForBracesInAnonymousMethods": true,
        "NewLinesForBracesInControlBlocks": true,
        "NewLinesForBracesInAnonymousTypes": true,
        "NewLinesForBracesInObjectCollectionArrayInitializers": true,
        "NewLinesForBracesInLambdaExpressionBody": true,
        "NewLineForElse": true,
        "NewLineForCatch": true,
        "NewLineForFinally": true,
        "NewLineForMembersInObjectInit": true,
        "NewLineForMembersInAnonymousTypes": true,
        "NewLineForClausesInQuery": true,
        "OrganizeImports": true
    },
    "RoslynExtensionsOptions": {
        "documentAnalysisTimeoutMs": 10000,
        "enableDecompilationSupport": true,
        "enableImportCompletion": true,
        "enableAnalyzersSupport": true,
        "locationPaths": ["//path_to/code_actions.dll"]
    }
}

```
