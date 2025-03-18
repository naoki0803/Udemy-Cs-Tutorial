## プロジェクトの作成方法

### 基本的な作成方法

```
 dotnet new console -n Sample101
```

new 第二引数にどのようなアプリケーションを作成するかを記述する

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

### help の確認

```

$ dotnet new --help

```

確認したい引数や、オプションの後ろで `--help` を記述する

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

## Console.WriteLine の利用方法

### 基本的な利用方法

```
Console.WriteLine("改行して");
Console.WriteLine("結果を出力");
// 改行して
// 結果を出力

Console.Write("改行なし");
Console.Write("で出力");
// 改行なしで出力
```

### 文字列補完 (javascript でいうテンプレートリテラル)

```
string firstName = "鈴木";
string lastName = "太郎";
Console.WriteLine($"私は、{firstName}{lastName}です");
// 私は鈴木たろうです

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

## ユーザーの入力の取得

Console.ReadLine();を利用する事で、実行時は該当行で処理が一次停止し、
ユーザーの入力が完了(Enter 押下)されると、処理が進むようになる。

戻り値として、ユーザーの入力した値が`文字列`として取得できる

```cs
string? inputValue1, inputValue2;
Console.Write("苗字を入力してください => ");
inputValue1 = Console.ReadLine();
Console.Write("名字を入力してください => ");
inputValue2 = Console.ReadLine();
Console.WriteLine($"あなたの名前は{inputValue1} {inputValue2}:です");
```

## if 文
基本構文は JavaScript と変わらない

ただし、cs は静的型付け言語なので、等価演算子は `===` ではなく、`==` を利用する
また、truthy / falsy という概念は cs にはなく、空文字やnullの判定は明示的なメソッド呼び出しが必要
※API連携時にはnullとundefinedの扱いを明確にする必要がある。

**空文字の扱い**	""はfalse	String.IsNullOrEmpty()で判定
**null/undefined**	両者ともfalse	nullのみ存在（undefinedはなし）
**コレクションの扱い**	空配列[]はtrue	空コレクションはnullでないがコンテナ自体のチェックが必要

```
csharp
// 空文字チェック
if (String.IsNullOrEmpty(text)) { /* 処理 */ }

// nullチェック（オブジェクトの場合）
if (obj == null) { /* 処理 */ }

// JSONデシリアライズ時のnull扱い
// Newtonsoft.Jsonの場合、nullはundefinedとして扱われない
// 必要な場合はNullValueHandling.Ignoreでプロパティを省略可能[7]
```

## switch 文
基本的な記述方法は JavaScript と同じ
※注意点として、フォールスルーの処理は構文エラーになる

```
int num = int.Parse(Console.ReadLine());
switch (num) {
    case 1:
    case 9: // caseを2つ指定することも可能
        Console.WriteLine("1 or 9 です");
        break;
    case 2:
        Console.WriteLine("2 です");
        break;
    case 3:
        Console.WriteLine("3 です");
        break;
    default:
        Console.WriteLine("1から3 もしくは 9 の整数を入力してください。");
        break;
}
```



## コードフォーマット関連

omnisharpは現状利用しておらず、C# Div Kit 内の機能でフォーマットしていそうだが、その設定実体がどこかがわからない。

.editorconfig を記述しても、記述がうまく反映しない。
原因不明。。。

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
