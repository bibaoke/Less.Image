<h2 style="text-align:center;">
	<span style="color:#24292E;font-family:-apple-system, BlinkMacSystemFont, " background-color:#ffffff;"="">һ���򵥵� C# ͼƬ����ģ�� ����&nbsp;<span style="color:#24292E;font-family:-apple-system, BlinkMacSystemFont, " background-color:#ffffff;"="">Less.Image&nbsp;</span><span style="color:#24292E;font-family:-apple-system, BlinkMacSystemFont, " background-color:#ffffff;"=""></span></span> 
</h2>
<p>
	<span>���� web ��Ŀ��˵����ͼƬ���в�ͬ�ߴ����С�Ǳ���ġ�</span> 
</p>
<p>
	<span>������д��֧�� IE6 �� web ��Ŀ�����ǵ� IE6 ��ͼƬ������Ч���Ǻܲ�ģ�Ҫ��ֹ���ͼƬ����������ţ���Ҫ�ڷ�����Ȱ�ͼƬ���ŵ��ʺϵĳߴ硣���� IE6 ��������̭�ˣ�����Ϊ��ҳ��ļ����ٶȣ��㻹��Ҫ�ڷ������˰�ͼƬ��С���ر������ںܶ������ƶ����������ҳ��Ϊ�˽�ʡ�û��������ѣ�ҲҪ�ڷ������˰�ͼƬ��С����÷���������Ӧ��ͼƬ����С������������ֵ���һ���ġ�</span> 
</p>
<p>
	��Լ���߰���ǰ����д��һЩ������������ͼƬ�Ĵ��롣�����޸�һ�¿�Դ������
</p>
<p>
	ȡһ�Ų����õ�ԭͼ���ߴ�Ϊ 600��721��
</p>
<p>
	<img alt="" src="http://bibaoke.com/img/PC2m0_kDK0Oma8tUy0sPUA?auth=post" /> 
</p>
<p>
	��ȡͼƬ��
</p>
<pre class="brush:csharp">Image origin = Image.FromFile(file);
</pre>
<p>
	��ͼƬ����Ϊ 300��200��
</p>
<pre class="brush:csharp">Image test1 = origin.Resize(300, 200);</pre>
<p>
	Ч�����£�
</p>
<p>
	<img style="width:50%;" alt="" src="http://bibaoke.com/img/bpWjdFtisEK4Ij8t1aDvRA?auth=post" /> 
</p>
<p>
	Resize �����������������ָ��ʲô���ߴ磬�������ͼƬ���вü�������ʹ�����ķ������Զ������ڿ������仹���ڸ߶�����䡣������������ڿ�������ġ������������������ʹ����һ�����أ�
</p>
<pre class="brush:csharp">Image test2 = 
&nbsp;&nbsp;&nbsp;&nbsp;origin.Resize(300, 200, ResizeMode.WidthFirst);</pre>
<p>
	Ч�����£�
</p>
<p>
	<img style="width:50%;" alt="" src="http://bibaoke.com/img/ZAKkQ1Qu5USjT9FICR8-dQ?auth=post" /> 
</p>
<p>
	���ͬ���ǰ�ͼƬ����Ϊ&nbsp;<span>300��200������ʹ���˲ü��ķ����������ĵ���������&nbsp;ResizeMode ��һ�� Resize ģʽѡ���&nbsp;<span>ResizeMode.</span><span>WidthFirst</span> ������ȣ���&nbsp;<span>ResizeMode.HeightFirst �߶�����</span>����ѡ�test2 ѡ���˿�����ȣ���˼�ǲ���ͼƬ�Ŀ�����κεĲü�����䣬����������ͼƬ��ԭͼ������ͬ��ֻ��ͼƬ�ĸ߶�����������test2 ����ͼƬ�ĸ߶������˲ü������ test2 ѡ��߶����ȣ�Ч���Ǻ� test1 һ���ģ�test1 ��������Ϊ���ܶ�ͼƬ���ü������Զ�ѡ���˸߶����ȡ�</span> 
</p>
<p>
	�������ŵķ������ձ����� web ��̵ķ��������ģ��ҿ����Ĳ�Ʒ����ʹ�òü��ķ���������΢�š�΢�����ü���Ȼ��ʹͼƬ����ʧ����һ���֣����Ա��������˵�������ý�����ÿ�����Ϊ������û������ĵ�ɫ��
</p>
<p>
	ʹ�� Crop ��������ָ��ʹ�òü���
</p>
<pre class="brush:csharp">Image test3 = origin.Crop(100, 100);</pre>
<p>
	���������еľŹ��񷽷���ʾЧ����
</p>
<p>
	<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<br />
<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<br />
<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;<img style="width:30%;" alt="" src="http://bibaoke.com/img/RvKfhYYotUuYUoulxVI8zQ?auth=post" />&nbsp;&nbsp;
</p>
<p>
	Less.Image �Ĳü��㷨�ǽ�ȡͼƬ���м䲿�ֵģ���Ϊ�󲿷�ͼƬ�����嶼���м䣬������������ͼƬ��΢����һ�ֲü��㷨�ǽ�ȡͼƬ���ϲ��ģ���������������еĸ߶��ر���ͼƬ�ģ�����ͼƬʽ�ĳ�΢�����������ȡ�
</p>
<p>
	�����ͼƬ�Ŀ�߱�û��Ҫ�󣬿���ʹ�ã�
</p>
<pre class="brush:csharp">Image test4 = origin.ResizeW(300);
</pre>
<p>
	�������˼�ǰ�ͼƬ�����ɿ�� 300 ���أ�Ч�����£�
</p>
<p>
	<img style="width:50%;" alt="" src="http://bibaoke.com/img/FT5DSLrIs0a-bbmDRAj78g?auth=post" /> 
</p>
<p>
	��������ǲ����ͼƬ���вü������ģ�������ԭͼ�Ŀ�߱ȡ���Ȼ��Ҳ����ָֻ���߶ȣ�
</p>
<pre class="brush:csharp">Image test5 = origin.ResizeH(200);
</pre>
<p>
	������һ�Ÿ߶� 200 ���ص�ͼƬ��
</p>
<p>
	<img style="width:28%;" alt="" src="http://bibaoke.com/img/lHtXGodvp0qXn1Vu4IdfbA?auth=post" /> 
</p>
<p>
	Less.Image ���ṩ�˽϶�����ط��������綨���ĵ�ɫ����ֵ�㷨�ȡ�����Ӧ����������ͼƬ���ŵĴ󲿷��������д��Щ�����ʱ��Ƚ����ˣ������ڼ侭���˺ܶ���ԣ��������ʮ��ͼƬ���������ţ��� Less.Image ���ڲ��ǲ��ᷢ���ڴ�й¶�ġ���֪������ System.Drawing �����ռ��£��ܶ��඼�Ƿ��йܵġ�
</p>
<p>
	Դ���룺<br />
<a href="https://github.com/bibaoke/Less.Image" target="_blank">https://github.com/bibaoke/Less.Image</a><br />
<a href="https://code.csdn.net/closurer/less-image/tree/master" target="_blank">https://code.csdn.net/closurer/less-image/tree/master</a> 
</p>
<p>
	Less.Image ��������ȱ�㡣һ������ gif ������������ʣ�µ�һ֡��ʧȥ�˶�����Ч����������Ϊ windows ���õ� png �����������ܺܺõ�ѹ��ͼƬ�����Զ� png �������ŵĻ���ͼƬռ�ÿռ��Ƚϴ��������ͼƬû��͸�����صĻ������ʹ�� jpg��
</p>
<p>
	�������и��õ��뷨����������ϵ��
</p>