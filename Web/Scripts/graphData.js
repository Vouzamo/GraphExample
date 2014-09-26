var width = 960,
    height = 500;

var color = d3.scale.category20();

var force = d3.layout.force()
    .gravity(.05)
    .distance(600)
    .charge(-1000)
    .linkDistance(300)
    .size([width, height]);

var svg = d3.select("body").append("svg")
    .attr("width", width)
    .attr("height", height);

var graph = getData();

console.log(graph);

var nodeMap = {};

graph.nodes.forEach(function (d) { nodeMap[d.name] = d; });

graph.edges.forEach(function (l) {
    l.source = nodeMap[l.source];
    l.target = nodeMap[l.target];
})

force.nodes(graph.nodes)
    .links(graph.edges)
    .start();

var link = svg.selectAll(".link")
    .data(graph.edges)
    .enter().append("line")
    .attr("class", "link")
    .style("stroke-width", function (d) {
        return Math.sqrt(d.value) + 1;
    });

var node = svg.selectAll(".node")
    .data(graph.nodes)
    .enter()
    .append("g")
    .attr("class", "node")
    .call(force.drag);

node.append("circle")
    .attr("cx", 0)
    .attr("cy", 0)
    .attr("r", 80)
    .style("fill", function (d) { return color(d.group); })

node.append("text")
    .attr("x", 0)
    .attr("y", 0)
    .text(function (d) { return d.name + " (" + d.group + ")"; });

force.on("tick", function () {
    link.attr("x1", function (d) { return d.source.x; })
        .attr("y1", function (d) { return d.source.y; })
        .attr("x2", function (d) { return d.target.x; })
        .attr("y2", function (d) { return d.target.y; });
    node.attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });
});


function getData() {
    return $.parseJSON($('#graphData').html());
}