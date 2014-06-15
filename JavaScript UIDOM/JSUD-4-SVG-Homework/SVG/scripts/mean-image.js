(function () {
  	var builder = getSvgBuilder('http://www.w3.org/2000/svg');
  	var svg = document.getElementById('the-svg'); 

  	(function buildText () {
  		svg.appendChild(builder.text(90,105,'#3E3F37',40,'M',0,900));
  		svg.appendChild(builder.text(95,157,'#282827',40,'E',0,900));
  		svg.appendChild(builder.text(93,214,'#E23337',40,'A',0,900));
      svg.appendChild(builder.text(93,270,'#8EC74E',40,'N',0,900));
  	}());

  	(function buildCircle1 () {
      svg.appendChild(builder.circle(200,100,55,'#3E3F37'));
      svg.appendChild(builder.path('M200 70 Q170 95 200 150','#5EB14A',3,'#5EB14A'));
      svg.appendChild(builder.path('M200 70 Q230 95 200 150','#449644',3,'#449644'));
    }());

    (function buildCircle2 () {
      svg.appendChild(builder.circle(200,150,55,'#282827'));
      svg.appendChild(builder.text(153,150,'#FFFFFF',25,'express',2));
    }());

    (function buildCircle3 () {
      svg.appendChild(builder.circle(200,204,55,'#E23337'));
      svg.appendChild(builder.path('M177 209 L 173 180 L 200 171 L 226 180 L 223 209','lightgrey',3,'none'));
      svg.appendChild(builder.path('M190 204 L 200 181 L 210 204','lightgrey',5,'none'));
    }());

    (function buildCircle4 () {
      svg.appendChild(builder.circle(200,253,55,'#8EC74E'));
      svg.appendChild(builder.polygon('162 243 172 248 172 263 165 260 165 253 162 251 159 253 159 260 152 263 152 248 162 243','fill: #47493F'));
      svg.appendChild(builder.polygon('187 243 197 248 197 258 187 263 177 258 177 248','fill: #FEFEFE'));
      svg.appendChild(builder.polygon('212 243 215 245 215 231 222 235 222 260 212 266 202 260 202 250 212 243','fill: #47493F'));
      svg.appendChild(builder.circle(212,255,3,'#8EC74E'));
      svg.appendChild(builder.polygon('239 243 249 248 249 252 242 255 236 255 244 261 239 266 229 260 229 248 239 243','fill: #47493F'));
      svg.appendChild(builder.circle(239,254,3,'#F2F8EC'));
    }());
}());



