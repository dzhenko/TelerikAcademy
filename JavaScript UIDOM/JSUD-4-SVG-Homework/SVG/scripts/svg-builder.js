function getSvgBuilder(svgNS) {
    function buildRect (x,y,width,height,fill) {
      var rect = document.createElementNS(svgNS,'rect');
      rect.setAttribute('x', x);
      rect.setAttribute('y', y);
      rect.setAttribute('width', width);
      rect.setAttribute('height', height);
      rect.setAttribute('fill', fill);
      return rect;
    }

    function buildText (x,y,fill,fontsize, txt, letterSpacing, fontWeight) {
      var text = document.createElementNS(svgNS,'text');
      text.setAttribute('x', x);
      text.setAttribute('y', y);
      text.setAttribute('fill', fill);
      text.setAttribute('font-size', fontsize);
      text.innerHTML = txt;

      if (letterSpacing) {
          text.setAttribute('letter-spacing', letterSpacing);
      };

      if (fontWeight) {
          text.setAttribute('font-weight', fontWeight);
      };

      return text;
    }

    function buildImage (x,y,width,height,link) {
      var image = document.createElementNS(svgNS,'image');
      image.setAttribute('x', x);
      image.setAttribute('y', y);
      image.setAttribute('width', width);
      image.setAttribute('height', height);
      image.setAttributeNS('http://www.w3.org/1999/xlink','href',link);
      return image;
    }

    function buildCircle (cx,cy,r,fill) {
      var circle = document.createElementNS(svgNS,'circle');
      circle.setAttribute('cx', cx);
      circle.setAttribute('cy', cy);
      circle.setAttribute('r', r);
      circle.setAttribute('fill', fill);
      return circle;
    }

    function buildPath (d,stroke,strokeWidth,fill) {
      var path = document.createElementNS(svgNS,'path');
      path.setAttribute('d', d);
      path.setAttribute('stroke', stroke);
      path.setAttribute('stroke-width', strokeWidth);
      path.setAttribute('fill', fill);
      return path;
    }

    function buildPolygon (points,style) {
      var polygon = document.createElementNS(svgNS,'polygon');
      polygon.setAttribute('points', points);
      polygon.setAttribute('style', style);
      return polygon;
    }

    return {
      rect:buildRect,
      text:buildText,
      image:buildImage,
      circle:buildCircle,
      path:buildPath,
      polygon:buildPolygon,
    }
  }