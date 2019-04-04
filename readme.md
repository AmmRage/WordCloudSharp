# Ported Repository Info

This project is ported from a Codeplex hosted repository.

* [orig repo](http://wordcloud.codeplex.com/)

* [orig author](http://www.codeplex.com/site/users/view/briancullen)

# install

[![NuGet](https://img.shields.io/nuget/v/WordCloudSharp.svg)](https://www.nuget.org/packages/WordCloudSharp)

# Usage

```
    var wordCloud = new WordCloud(width, height, mask: mask, allowVerical: true, fontname: "YouYuan");
    wordCloud.OnProgress += Wc_OnProgress;
    var image = wordCloud.Draw(Words, Frequencies);
```

for more details, please ref to the usage in WordCloudTestApp

# Examples

without mask: 

![alt text][without]

[without]: https://github.com/AmmRage/WordCloudSharp/blob/master/images/exmaple.jpg "without mask"

with mask: 

![alt text][with]

[with]: https://github.com/AmmRage/WordCloudSharp/blob/master/images/example_with_mask.jpg "with mask"

# What's New
Took [Word_Cloud](https://github.com/amueller/word_cloud) as ref.

* Add interface generating word cloud with mask.

# To do

1. sync features from [Word_Cloud](https://github.com/amueller/word_cloud)

2. add .net core support

3. test & CI & Nuget package

