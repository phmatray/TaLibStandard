window.D3Charts = {
    createCandlestickChart: function (elementId, data, config) {
        // Clear any existing chart
        d3.select(`#${elementId}`).selectAll("*").remove();

        const margin = { top: 20, right: 80, bottom: 80, left: 80 };
        const width = config.width - margin.left - margin.right;
        const height = config.height - margin.top - margin.bottom;

        // Create SVG
        const svg = d3.select(`#${elementId}`)
            .append("svg")
            .attr("width", config.width)
            .attr("height", config.height);

        const g = svg.append("g")
            .attr("transform", `translate(${margin.left},${margin.top})`);

        // Parse dates
        data.forEach(d => {
            d.date = new Date(d.date);
        });

        // Set scales
        const x = d3.scaleBand()
            .domain(data.map(d => d.date))
            .range([0, width])
            .padding(0.3);

        const y = d3.scaleLinear()
            .domain([
                d3.min(data, d => d.low) * 0.95,
                d3.max(data, d => d.high) * 1.05
            ])
            .range([height, 0]);

        // Add X axis
        const xAxis = g.append("g")
            .attr("transform", `translate(0,${height})`)
            .call(d3.axisBottom(x)
                .tickFormat(d3.timeFormat("%b %d"))
                .tickValues(x.domain().filter((d, i) => i % Math.ceil(data.length / 10) === 0)));

        xAxis.selectAll("text")
            .style("text-anchor", "end")
            .attr("dx", "-.8em")
            .attr("dy", ".15em")
            .attr("transform", "rotate(-45)");

        // Add Y axis with dollar formatting
        g.append("g")
            .call(d3.axisLeft(y)
                .tickFormat(d => `$${d.toFixed(2)}`));

        // Add Y axis label
        g.append("text")
            .attr("transform", "rotate(-90)")
            .attr("y", 0 - margin.left)
            .attr("x", 0 - (height / 2))
            .attr("dy", "1em")
            .style("text-anchor", "middle")
            .text("Price ($)");

        // Create tooltip
        const tooltip = d3.select("body").append("div")
            .attr("class", "d3-tooltip")
            .style("opacity", 0)
            .style("position", "absolute")
            .style("background", "rgba(0, 0, 0, 0.8)")
            .style("color", "white")
            .style("padding", "8px")
            .style("border-radius", "4px")
            .style("font-size", "12px");

        // Draw high-low lines
        g.selectAll(".highlow")
            .data(data)
            .enter().append("line")
            .attr("class", "highlow")
            .attr("x1", d => x(d.date) + x.bandwidth() / 2)
            .attr("x2", d => x(d.date) + x.bandwidth() / 2)
            .attr("y1", d => y(d.high))
            .attr("y2", d => y(d.low))
            .attr("stroke", d => d.close > d.open ? "#26a69a" : "#ef5350")
            .attr("stroke-width", 1);

        // Draw candlestick bodies
        g.selectAll(".candle")
            .data(data)
            .enter().append("rect")
            .attr("class", "candle")
            .attr("x", d => x(d.date))
            .attr("y", d => y(Math.max(d.open, d.close)))
            .attr("width", x.bandwidth())
            .attr("height", d => Math.abs(y(d.open) - y(d.close)))
            .attr("fill", d => d.close > d.open ? "#26a69a" : "#ef5350")
            .attr("stroke", d => d.close > d.open ? "#26a69a" : "#ef5350")
            .on("mouseover", function (event, d) {
                tooltip.transition()
                    .duration(200)
                    .style("opacity", .9);
                tooltip.html(`Date: ${d3.timeFormat("%Y-%m-%d")(d.date)}<br/>
                             Open: $${d.open.toFixed(2)}<br/>
                             High: $${d.high.toFixed(2)}<br/>
                             Low: $${d.low.toFixed(2)}<br/>
                             Close: $${d.close.toFixed(2)}<br/>
                             Volume: ${d.volume.toLocaleString()}`)
                    .style("left", (event.pageX + 10) + "px")
                    .style("top", (event.pageY - 28) + "px");
            })
            .on("mouseout", function (d) {
                tooltip.transition()
                    .duration(500)
                    .style("opacity", 0);
            });

        // Add volume chart if enabled
        if (config.showVolume) {
            const volumeHeight = 80;
            const volumeMargin = { top: 20, right: margin.right, bottom: margin.bottom, left: margin.left };
            
            const volumeSvg = d3.select(`#${elementId}`)
                .append("svg")
                .attr("width", config.width)
                .attr("height", volumeHeight + volumeMargin.top + volumeMargin.bottom)
                .style("margin-top", "20px");

            const volumeG = volumeSvg.append("g")
                .attr("transform", `translate(${volumeMargin.left},${volumeMargin.top})`);

            const volumeY = d3.scaleLinear()
                .domain([0, d3.max(data, d => d.volume)])
                .range([volumeHeight, 0]);

            volumeG.append("g")
                .call(d3.axisLeft(volumeY)
                    .tickFormat(d3.format(".2s")));

            volumeG.selectAll(".volume")
                .data(data)
                .enter().append("rect")
                .attr("class", "volume")
                .attr("x", d => x(d.date))
                .attr("y", d => volumeY(d.volume))
                .attr("width", x.bandwidth())
                .attr("height", d => volumeHeight - volumeY(d.volume))
                .attr("fill", d => d.close > d.open ? "#26a69a" : "#ef5350")
                .attr("opacity", 0.5);

            volumeG.append("text")
                .attr("transform", "rotate(-90)")
                .attr("y", 0 - volumeMargin.left)
                .attr("x", 0 - (volumeHeight / 2))
                .attr("dy", "1em")
                .style("text-anchor", "middle")
                .text("Volume");
        }

        return {
            x: x,
            y: y,
            g: g,
            width: width,
            height: height
        };
    },

    addIndicator: function (elementId, chartInstance, indicatorData, config) {
        const { x, y, g, width, height } = chartInstance;

        const line = d3.line()
            .x((d, i) => x(indicatorData.dates[i]) + x.bandwidth() / 2)
            .y(d => y(d))
            .defined(d => d !== null && !isNaN(d));

        g.append("path")
            .datum(indicatorData.values)
            .attr("class", `indicator-${config.name}`)
            .attr("fill", "none")
            .attr("stroke", config.color || "#ff6f00")
            .attr("stroke-width", config.strokeWidth || 2)
            .attr("d", line);

        // Add to legend
        const legend = g.select(".legend");
        if (legend.empty()) {
            g.append("g")
                .attr("class", "legend")
                .attr("transform", `translate(10, 10)`);
        }

        const legendItems = g.select(".legend").selectAll(".legend-item").nodes().length;
        g.select(".legend")
            .append("text")
            .attr("class", "legend-item")
            .attr("x", legendItems * 100)
            .attr("y", 0)
            .attr("fill", config.color || "#ff6f00")
            .style("font-size", "12px")
            .text(config.name);
    },

    addBands: function (elementId, chartInstance, upperData, lowerData, config) {
        const { x, y, g } = chartInstance;

        const area = d3.area()
            .x((d, i) => x(upperData.dates[i]) + x.bandwidth() / 2)
            .y0((d, i) => y(lowerData.values[i]))
            .y1((d, i) => y(upperData.values[i]))
            .defined((d, i) => upperData.values[i] !== null && lowerData.values[i] !== null);

        g.append("path")
            .datum(upperData.values)
            .attr("class", `band-${config.name}`)
            .attr("fill", config.fillColor || "#1976d2")
            .attr("opacity", config.fillOpacity || 0.1)
            .attr("d", area);

        // Add upper band line
        const upperLine = d3.line()
            .x((d, i) => x(upperData.dates[i]) + x.bandwidth() / 2)
            .y(d => y(d))
            .defined(d => d !== null && !isNaN(d));

        g.append("path")
            .datum(upperData.values)
            .attr("class", `band-upper-${config.name}`)
            .attr("fill", "none")
            .attr("stroke", config.upperColor || "#4caf50")
            .attr("stroke-width", 1)
            .attr("stroke-dasharray", "5,5")
            .attr("d", upperLine);

        // Add lower band line
        const lowerLine = d3.line()
            .x((d, i) => x(lowerData.dates[i]) + x.bandwidth() / 2)
            .y(d => y(d))
            .defined(d => d !== null && !isNaN(d));

        g.append("path")
            .datum(lowerData.values)
            .attr("class", `band-lower-${config.name}`)
            .attr("fill", "none")
            .attr("stroke", config.lowerColor || "#f44336")
            .attr("stroke-width", 1)
            .attr("stroke-dasharray", "5,5")
            .attr("d", lowerLine);
    },

    addPatternMarkers: function (elementId, chartInstance, patterns, data) {
        const { x, y, g } = chartInstance;

        const patternGroup = g.append("g")
            .attr("class", "pattern-markers");

        // Create pattern tooltip
        const patternTooltip = d3.select("body").append("div")
            .attr("class", "d3-pattern-tooltip")
            .style("opacity", 0)
            .style("position", "absolute")
            .style("background", "rgba(0, 0, 0, 0.9)")
            .style("color", "white")
            .style("padding", "12px")
            .style("border-radius", "6px")
            .style("font-size", "12px")
            .style("pointer-events", "none")
            .style("box-shadow", "0 2px 8px rgba(0,0,0,0.3)");

        patterns.forEach(pattern => {
            const dataPoint = data[pattern.index];
            if (!dataPoint) return;

            const markerX = x(dataPoint.date) + x.bandwidth() / 2;
            const markerY = pattern.value > 0 ? y(dataPoint.high) - 20 : y(dataPoint.low) + 20;
            const color = pattern.value > 0 ? "#4caf50" : "#f44336";
            const icon = pattern.value > 0 ? "▲" : "▼";

            // Create a group for each pattern
            const markerGroup = patternGroup.append("g")
                .attr("class", "pattern-marker")
                .style("cursor", "pointer");

            // Add connecting line
            markerGroup.append("line")
                .attr("x1", markerX)
                .attr("y1", pattern.value > 0 ? y(dataPoint.high) : y(dataPoint.low))
                .attr("x2", markerX)
                .attr("y2", markerY)
                .attr("stroke", color)
                .attr("stroke-width", 1)
                .attr("stroke-dasharray", "2,2")
                .attr("opacity", 0.6);

            // Add background circle
            markerGroup.append("circle")
                .attr("cx", markerX)
                .attr("cy", markerY)
                .attr("r", 12)
                .attr("fill", "white")
                .attr("stroke", color)
                .attr("stroke-width", 2);

            // Add pattern icon
            markerGroup.append("text")
                .attr("x", markerX)
                .attr("y", markerY + 4)
                .attr("text-anchor", "middle")
                .attr("fill", color)
                .style("font-size", "14px")
                .style("font-weight", "bold")
                .text(icon);

            // Add pattern name below
            markerGroup.append("text")
                .attr("x", markerX)
                .attr("y", markerY + 25)
                .attr("text-anchor", "middle")
                .attr("fill", color)
                .style("font-size", "11px")
                .style("font-weight", "600")
                .style("text-shadow", "1px 1px 2px rgba(255,255,255,0.8)")
                .text(pattern.patternName);

            // Add hover effects
            markerGroup
                .on("mouseover", function(event) {
                    d3.select(this).select("circle")
                        .transition()
                        .duration(200)
                        .attr("r", 15);
                    
                    patternTooltip.transition()
                        .duration(200)
                        .style("opacity", .95);
                    
                    const signal = pattern.value > 0 ? "Bullish" : pattern.value < 0 ? "Bearish" : "Neutral";
                    const signalColor = pattern.value > 0 ? "#4caf50" : pattern.value < 0 ? "#f44336" : "#999";
                    
                    patternTooltip.html(`
                        <div style="font-weight: bold; margin-bottom: 8px; color: ${signalColor}">
                            ${pattern.patternName}
                        </div>
                        <div style="margin-bottom: 4px;">
                            <strong>Date:</strong> ${d3.timeFormat("%Y-%m-%d")(dataPoint.date)}
                        </div>
                        <div style="margin-bottom: 4px;">
                            <strong>Signal:</strong> <span style="color: ${signalColor}">${signal}</span>
                        </div>
                        <div style="margin-bottom: 4px;">
                            <strong>Price:</strong> $${dataPoint.close.toFixed(2)}
                        </div>
                        <div>
                            <strong>Volume:</strong> ${dataPoint.volume.toLocaleString()}
                        </div>
                    `)
                        .style("left", (event.pageX + 10) + "px")
                        .style("top", (event.pageY - 28) + "px");
                })
                .on("mouseout", function() {
                    d3.select(this).select("circle")
                        .transition()
                        .duration(200)
                        .attr("r", 12);
                    
                    patternTooltip.transition()
                        .duration(500)
                        .style("opacity", 0);
                });
        });
    },

    createSecondaryIndicator: function (elementId, data, indicatorData, config) {
        const margin = { top: 20, right: 80, bottom: 40, left: 80 };
        const width = config.width - margin.left - margin.right;
        const height = 200 - margin.top - margin.bottom;

        const svg = d3.select(`#${elementId}`)
            .append("svg")
            .attr("width", config.width)
            .attr("height", 200)
            .style("margin-top", "20px");

        const g = svg.append("g")
            .attr("transform", `translate(${margin.left},${margin.top})`);

        // Parse dates if needed
        data.forEach(d => {
            if (!(d.date instanceof Date)) {
                d.date = new Date(d.date);
            }
        });

        // Set scales
        const x = d3.scaleBand()
            .domain(data.map(d => d.date))
            .range([0, width])
            .padding(0.3);

        let yDomain = [
            d3.min(indicatorData.values, d => d) * 0.95,
            d3.max(indicatorData.values, d => d) * 1.05
        ];

        // Special handling for RSI
        if (config.name === "RSI") {
            yDomain = [0, 100];
        }

        const y = d3.scaleLinear()
            .domain(yDomain)
            .range([height, 0]);

        // Add axes
        g.append("g")
            .attr("transform", `translate(0,${height})`)
            .call(d3.axisBottom(x)
                .tickFormat(d3.timeFormat("%b %d"))
                .tickValues(x.domain().filter((d, i) => i % Math.ceil(data.length / 10) === 0)));

        g.append("g")
            .call(d3.axisLeft(y));

        // Add Y axis label
        g.append("text")
            .attr("transform", "rotate(-90)")
            .attr("y", 0 - margin.left)
            .attr("x", 0 - (height / 2))
            .attr("dy", "1em")
            .style("text-anchor", "middle")
            .text(config.name);

        // Draw indicator line
        const line = d3.line()
            .x((d, i) => x(indicatorData.dates[i]) + x.bandwidth() / 2)
            .y(d => y(d))
            .defined(d => d !== null && !isNaN(d));

        g.append("path")
            .datum(indicatorData.values)
            .attr("fill", "none")
            .attr("stroke", config.color || "#1976d2")
            .attr("stroke-width", 2)
            .attr("d", line);

        // Add RSI levels if RSI
        if (config.name === "RSI") {
            [30, 70].forEach(level => {
                g.append("line")
                    .attr("x1", 0)
                    .attr("y1", y(level))
                    .attr("x2", width)
                    .attr("y2", y(level))
                    .attr("stroke", level === 70 ? "#ff0000" : "#00ff00")
                    .attr("stroke-dasharray", "5,5")
                    .attr("opacity", 0.5);

                g.append("text")
                    .attr("x", 5)
                    .attr("y", y(level) - 5)
                    .attr("fill", level === 70 ? "#ff0000" : "#00ff00")
                    .style("font-size", "10px")
                    .text(level);
            });
        }

        return { x, y, g, width, height };
    },

    addSignalLine: function (elementId, chartInstance, signalData, config) {
        const { x, y, g } = chartInstance;

        const line = d3.line()
            .x((d, i) => x(signalData.dates[i]) + x.bandwidth() / 2)
            .y(d => y(d))
            .defined(d => d !== null && !isNaN(d));

        g.append("path")
            .datum(signalData.values)
            .attr("fill", "none")
            .attr("stroke", config.color || "#ff6f00")
            .attr("stroke-width", 2)
            .attr("d", line);
    },

    addHistogram: function (elementId, chartInstance, histogramData, config) {
        const { x, y, g, height } = chartInstance;

        const zeroY = y(0);

        g.selectAll(".histogram")
            .data(histogramData.values)
            .enter().append("rect")
            .attr("class", "histogram")
            .attr("x", (d, i) => x(histogramData.dates[i]))
            .attr("y", d => d >= 0 ? y(d) : zeroY)
            .attr("width", x.bandwidth())
            .attr("height", d => Math.abs(y(d) - zeroY))
            .attr("fill", d => d >= 0 ? "#4caf50" : "#f44336")
            .attr("opacity", 0.5);
    },

    dispose: function (elementId) {
        d3.select(`#${elementId}`).selectAll("*").remove();
        d3.select("body").selectAll(".d3-tooltip").remove();
        d3.select("body").selectAll(".d3-pattern-tooltip").remove();
    }
};