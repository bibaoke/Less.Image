<h2 style="text-align:center;">
    一个简单的 C# 图片缩放模块 ——&nbsp;Less.Image
</h2>
<p>
    <span>对于 web 项目来说，对图片进行不同尺寸的缩小是必须的。</span>
</p>
<p>
    <span>如果你编写过支持 IE6 的 web 项目，你会记得 IE6 对图片的缩放效果是很差的，要禁止你的图片被浏览器缩放，就要在服务端先把图片缩放到适合的尺寸。现在 IE6 基本被淘汰了，但是为了页面的加载速度，你还是要在服务器端把图片缩小。特别是现在很多人用移动流量浏览网页，为了节省用户的流量费，也要在服务器端把图片缩小，最好服务器端响应的图片，大小和在浏览器呈现的是一样的。</span>
</p>
<p>
    大约在七八年前，我写了一些服务器端缩放图片的代码。现在修改一下开源出来。
</p>
<p>
    取一张测试用的原图，尺寸为 600×721：
</p>
<p>
    <img alt="" src="http://bibaoke.com/img/PC2m0_kDK0Oma8tUy0sPUA?auth=post" />
</p>
<p>
    读取图片：
</p>
<pre class="brush:csharp">Image origin = Image.FromFile(file);
</pre>
<p>
    把图片调整为 300×200：
</p>
<pre class="brush:csharp">Image test1 = origin.Resize(300, 200);</pre>
<p>
    效果如下：
</p>
<p>
    <img style="width:50%;" alt="" src="http://bibaoke.com/img/bpWjdFtisEK4Ij8t1aDvRA?auth=post" />
</p>
<p>
    Resize 方法的这个重载无论指定什么样尺寸，都不会对图片进行裁剪，而是使用填充的方法，自动计算在宽度上填充还是在高度上填充。上面的例子是在宽度上填充的。如果不想这样，可以使用另一个重载：
</p>
<pre class="brush:csharp">Image test2 = 
&nbsp;&nbsp;&nbsp;&nbsp;origin.Resize(300, 200, ResizeMode.WidthFirst);</pre>
<p>
    效果如下：
</p>
<p>
    <img style="width:50%;" alt="" src="http://bibaoke.com/img/ZAKkQ1Qu5USjT9FICR8-dQ?auth=post" />
</p>
<p>
    这次同样是把图片调整为&nbsp;<span>300×200，但是使用了裁剪的方法。函数的第三个参数&nbsp;ResizeMode 是一个 Resize 模式选项，有&nbsp;<span>ResizeMode.</span><span>WidthFirst</span> 宽度优先，和&nbsp;<span>ResizeMode.HeightFirst 高度优先</span>两个选项。test2 选择了宽度优先，意思是不在图片的宽度做任何的裁剪和填充，如果调整后的图片和原图比例不同，只在图片的高度上做调整。test2 就在图片的高度上做了裁剪。如果 test2 选择高度优先，效果是和 test1 一样的，test1 函数是因为不能对图片做裁剪，而自动选择了高度优先。</span>
</p>
<p>
    这种缩放的方法是普遍用在 web 编程的服务端上面的，我看到的产品都会使用裁剪的方法，比如微信、微博。裁剪虽然会使图片“损失”了一部分，但对比起填充来说，可以让界面更好看，因为不会有没有意义的底色。
</p>
<p>
    使用 Crop 方法可以指定使用裁剪：
</p>
<pre class="brush:csharp">Image test3 = origin.Crop(180, 180);</pre>
<p>
    用现在流行的九宫格方法演示效果：
</p>
<p>
    <img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<br />
    <img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<br />
    <img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;
</p>
<p>
    Less.Image 的裁剪算法是截取图片的中间部分的，因为大部分图片的主体都在中间，比如杨幂这张图片。微博有一种裁剪算法是截取图片的上部的，这是针对现在流行的高度特别大的图片的，比如图片式的长微博，连环画等。
</p>
<p>
    如果对图片的宽高比没有要求，可以使用：
</p>
<pre class="brush:csharp">Image test4 = origin.ResizeW(300);
</pre>
<p>
    代码的意思是把图片调整成宽度 300 像素，效果如下：
</p>
<p>
    <img style="width:50%;" alt="" src="http://bibaoke.com/img/FT5DSLrIs0a-bbmDRAj78g?auth=post" />
</p>
<p>
    这个方法是不会对图片进行裁剪或填充的，保留了原图的宽高比。当然，也可以只指定高度：
</p>
<pre class="brush:csharp">Image test5 = origin.ResizeH(200);
</pre>
<p>
    生成了一张高度 200 像素的图片：
</p>
<p>
    <img style="width:28%;" alt="" src="http://bibaoke.com/img/lHtXGodvp0qXn1Vu4IdfbA?auth=post" />
</p>
<p>
    Less.Image 还提供了较多的重载方法，比如定填充的底色，插值算法等。可以应付服务器端图片缩放的大部分情况。我写这些代码的时间比较早了，在这期间经过了很多测试，处理过数十万图片的批量缩放，在 Less.Image 的内部是不会发生内存泄露的。你知道，在 System.Drawing 命名空间下，很多类都是非托管的。
</p>
<p>
    源代码：<br />
    <a href="https://github.com/bibaoke/Less.Image" target="_blank">https://github.com/bibaoke/Less.Image</a><br />
    <a href="https://code.csdn.net/closurer/less-image/tree/master" target="_blank">https://code.csdn.net/closurer/less-image/tree/master</a>
</p>
<p>
    Less.Image 还有两个缺点。一是缩放 gif 动画，处理后会剩下第一帧，失去了动画的效果；二是因为 windows 内置的 png 编码器并不能很好地压缩图片，所以对 png 进行缩放的话，图片占用空间会比较大。所以如果图片没有透明像素的话，最好使用 jpg。
</p>
<p>
    如果大家有更好的想法，请与我联系。
</p>