SharpMarkdown
=====
���M��ΥH��RMarkdown��󵲺c�A²�����NMarkdown����ഫ������C

### �ֳt�W��
```csharp
using SharpMarkdown;
...(something)...
//�ഫ��Markdown���e����
var mdContent = Markdown.Parse(text);
//�i�泹�`��R
var mdSection = mdContent.ToSection();
//�bMarkdown���e���M��ѦҼ���
var tag1 = mdSection.FindTag("1");
...(something)...
```
> �ԲӪ��ϥνd�ҥi��TestConsole�M��

### Demo
1.��R���`���c![Imgur](http://i.imgur.com/2dxOSaP.png)
2.���`���c��R���G![Imgur](http://i.imgur.com/QfbhFx3.png)
