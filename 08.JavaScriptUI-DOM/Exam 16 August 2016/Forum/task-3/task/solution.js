function solve() {
	return function() {
		var template = [
			'<h1>{{title}}</h1>'+
	'<ul>'+
		'{{#each posts}}'+
			'<li>'+
				'<div class="post">'+
					'<p class="author">'+
						'{{#if author}}'+
							'<a class="user" href="/user/{{this.author}}">{{this.author}}</a>'+
							'{{else}}'+
							'<a class="anonymous">Anonymous</a>'+
							'{{/if}}'+
					'</p>'+
					'<pre class="content">{{{this.text}}}</pre>'+
				'</div>'+
				'<ul>'+
				'{{#if comments}}'+
					'{{#each comments}}'+
						'{{#unless deleted}}'+
							'<li>'+
								'<div class="comment">'+
									'<p class="author">'+
									'{{#if author}}'+
											'<a class="user" href="/user/{{this.author}}">{{this.author}}</a>'+
											'{{else}}'+
											'<a class="anonymous">Anonymous</a>'+
											'{{/if}}'+
									'</p>'+
									'<pre class="content">{{{this.text}}}</pre>'+
								'</div>'+
							'</li>'+
							'{{/unless}}'+
					'{{/each}}'+
				'{{/if}}'+
			'</li>'+
	'</ul>'+
	'{{/each}}'
		].join('\n');

		return template;
	}
}

// submit the above

if(typeof module !== 'undefined') {
	module.exports = solve;
}
