// ----- The component

Vue.component('zz-button-progress', {
  props: ['text'],
  data: function () {
    return {
      progress: null,
      active: false,
      done: false,
      check: false };

  },
  methods: {
    /**
              * Changes the value of the attribute 'zz-button-progress'
              * Changing its value will change the percentage of the
              * progress of the button.
              */
    moveProgress: function (progress) {
      this.progress = progress;
    },
    /**
        * Reset the button progress to its original state.
        */
    resetProgress: function () {
      this.progress = null;
      this.active = false;
      this.done = false;
      this.check = false;
    },
    /**
        * Event handler for click event
        */
    progressClickEvent: function () {
      if (this.active === false && this.done === false) {
        this.active = true;
      }
    },
    /**
        * Event handler for transitionend event
        */
    progressTransitionEndEvent: function (evt) {
      if (this.progress === null && this.active === true) {
        this.progress = 0;

        this.$emit('progress');
      } else
      if (this.done === true) {
        this.check = true;
      }
    },
    /**
        * Event handler for animationend event
        */
    progressAnimationEndEvent: function (evt) {
      if (evt.animationName == 'progress-done-pre') {
        this.done = true;
        this.active = false;
        this.progress = null;
      } else
      if (evt.animationName == 'progress-done-post') {
        this.$emit('progress-finished');
      }
    } },

  template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
  el: '#app',
  methods: {
    moveProgress: function (progress = 0) {
      // This is just an example progress.
      // In real-world application, return from ajax process may be used
      var progressTimeout = setTimeout(() => {
        clearTimeout(progressTimeout);

        if (progress < 100) {
          let newProgress = progress + 1;
          this.$refs.zzUpload.moveProgress(newProgress);
          this.moveProgress(newProgress);
        }
      }, 1000);
    },
    endProgress: function () {
      var endProgressTimeout = setTimeout(() => {
        clearTimeout(endProgressTimeout);

        this.$refs.zzUpload.resetProgress();
      }, 5000);
        }
    }
});



// This is BTN2  EXAMPLE 2
// ----- The component

Vue.component('zz-button-progress', {
    props: ['text'],
    data: function () {
        return {
            progress: null,
            active: false,
            done: false,
            check: false
        };

    },
    methods: {
        /**
                  * Changes the value of the attribute 'zz-button-progress'
                  * Changing its value will change the percentage of the
                  * progress of the button.
                  */
        moveProgress: function (progress) {
            this.progress = progress;
        },
        /**
            * Reset the button progress to its original state.
            */
        resetProgress: function () {
            this.progress = null;
            this.active = false;
            this.done = false;
            this.check = false;
        },
        /**
            * Event handler for click event
            */
        progressClickEvent: function () {
            if (this.active === false && this.done === false) {
                this.active = true;
            }
        },
        /**
            * Event handler for transitionend event
            */
        progressTransitionEndEvent: function (evt) {
            if (this.progress === null && this.active === true) {
                this.progress = 0;

                this.$emit('progress');
            } else
                if (this.done === true) {
                    this.check = true;
                }
        },
        /**
            * Event handler for animationend event
            */
        progressAnimationEndEvent: function (evt) {
            if (evt.animationName == 'progress-done-pre') {
                this.done = true;
                this.active = false;
                this.progress = null;
            } else
                if (evt.animationName == 'progress-done-post') {
                    this.$emit('progress-finished');
                }
        }
    },

    template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
    el: '#app2',
    methods: {
        moveProgress: function (progress = 0) {
            // This is just an example progress.
            // In real-world application, return from ajax process may be used
            var progressTimeout = setTimeout(() => {
                clearTimeout(progressTimeout);

                if (progress < 100) {
                    let newProgress = progress + 1;
                    this.$refs.zzUpload.moveProgress(newProgress);
                    this.moveProgress(newProgress);
                }
            }, 1000);
        },
        endProgress: function () {
            var endProgressTimeout = setTimeout(() => {
                clearTimeout(endProgressTimeout);

                this.$refs.zzUpload.resetProgress();
            }, 5000);
        }
    }
});


// This is BTN3  EXAMPLE 3
// ----- The component

Vue.component('zz-button-progress', {
    props: ['text'],
    data: function () {
        return {
            progress: null,
            active: false,
            done: false,
            check: false
        };

    },
    methods: {
        /**
                  * Changes the value of the attribute 'zz-button-progress'
                  * Changing its value will change the percentage of the
                  * progress of the button.
                  */
        moveProgress: function (progress) {
            this.progress = progress;
        },
        /**
            * Reset the button progress to its original state.
            */
        resetProgress: function () {
            this.progress = null;
            this.active = false;
            this.done = false;
            this.check = false;
        },
        /**
            * Event handler for click event
            */
        progressClickEvent: function () {
            if (this.active === false && this.done === false) {
                this.active = true;
            }
        },
        /**
            * Event handler for transitionend event
            */
        progressTransitionEndEvent: function (evt) {
            if (this.progress === null && this.active === true) {
                this.progress = 0;

                this.$emit('progress');
            } else
                if (this.done === true) {
                    this.check = true;
                }
        },
        /**
            * Event handler for animationend event
            */
        progressAnimationEndEvent: function (evt) {
            if (evt.animationName == 'progress-done-pre') {
                this.done = true;
                this.active = false;
                this.progress = null;
            } else
                if (evt.animationName == 'progress-done-post') {
                    this.$emit('progress-finished');
                }
        }
    },

    template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
    el: '#app3',
    methods: {
        moveProgress: function (progress = 0) {
            // This is just an example progress.
            // In real-world application, return from ajax process may be used
            var progressTimeout = setTimeout(() => {
                clearTimeout(progressTimeout);

                if (progress < 100) {
                    let newProgress = progress + 1;
                    this.$refs.zzUpload.moveProgress(newProgress);
                    this.moveProgress(newProgress);
                }
            }, 1000);
        },
        endProgress: function () {
            var endProgressTimeout = setTimeout(() => {
                clearTimeout(endProgressTimeout);

                this.$refs.zzUpload.resetProgress();
            }, 5000);
        }
    }
});


// BTN4  EXAMPLE 4
// ----- The component

Vue.component('zz-button-progress', {
    props: ['text'],
    data: function () {
        return {
            progress: null,
            active: false,
            done: false,
            check: false
        };

    },
    methods: {
        /**
                  * Changes the value of the attribute 'zz-button-progress'
                  * Changing its value will change the percentage of the
                  * progress of the button.
                  */
        moveProgress: function (progress) {
            this.progress = progress;
        },
        /**
            * Reset the button progress to its original state.
            */
        resetProgress: function () {
            this.progress = null;
            this.active = false;
            this.done = false;
            this.check = false;
        },
        /**
            * Event handler for click event
            */
        progressClickEvent: function () {
            if (this.active === false && this.done === false) {
                this.active = true;
            }
        },
        /**
            * Event handler for transitionend event
            */
        progressTransitionEndEvent: function (evt) {
            if (this.progress === null && this.active === true) {
                this.progress = 0;

                this.$emit('progress');
            } else
                if (this.done === true) {
                    this.check = true;
                }
        },
        /**
            * Event handler for animationend event
            */
        progressAnimationEndEvent: function (evt) {
            if (evt.animationName == 'progress-done-pre') {
                this.done = true;
                this.active = false;
                this.progress = null;
            } else
                if (evt.animationName == 'progress-done-post') {
                    this.$emit('progress-finished');
                }
        }
    },

    template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
    el: '#app4',
    methods: {
        moveProgress: function (progress = 0) {
            // This is just an example progress.
            // In real-world application, return from ajax process may be used
            var progressTimeout = setTimeout(() => {
                clearTimeout(progressTimeout);

                if (progress < 100) {
                    let newProgress = progress + 1;
                    this.$refs.zzUpload.moveProgress(newProgress);
                    this.moveProgress(newProgress);
                }
            }, 1000);
        },
        endProgress: function () {
            var endProgressTimeout = setTimeout(() => {
                clearTimeout(endProgressTimeout);

                this.$refs.zzUpload.resetProgress();
            }, 5000);
        }
    }
});


// BTN6  EXAMPLE 6
// ----- The component

Vue.component('zz-button-progress', {
    props: ['text'],
    data: function () {
        return {
            progress: null,
            active: false,
            done: false,
            check: false
        };

    },
    methods: {
        /**
                  * Changes the value of the attribute 'zz-button-progress'
                  * Changing its value will change the percentage of the
                  * progress of the button.
                  */
        moveProgress: function (progress) {
            this.progress = progress;
        },
        /**
            * Reset the button progress to its original state.
            */
        resetProgress: function () {
            this.progress = null;
            this.active = false;
            this.done = false;
            this.check = false;
        },
        /**
            * Event handler for click event
            */
        progressClickEvent: function () {
            if (this.active === false && this.done === false) {
                this.active = true;
            }
        },
        /**
            * Event handler for transitionend event
            */
        progressTransitionEndEvent: function (evt) {
            if (this.progress === null && this.active === true) {
                this.progress = 0;

                this.$emit('progress');
            } else
                if (this.done === true) {
                    this.check = true;
                }
        },
        /**
            * Event handler for animationend event
            */
        progressAnimationEndEvent: function (evt) {
            if (evt.animationName == 'progress-done-pre') {
                this.done = true;
                this.active = false;
                this.progress = null;
            } else
                if (evt.animationName == 'progress-done-post') {
                    this.$emit('progress-finished');
                }
        }
    },

    template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
    el: '#app6',
    methods: {
        moveProgress: function (progress = 0) {
            // This is just an example progress.
            // In real-world application, return from ajax process may be used
            var progressTimeout = setTimeout(() => {
                clearTimeout(progressTimeout);

                if (progress < 100) {
                    let newProgress = progress + 1;
                    this.$refs.zzUpload.moveProgress(newProgress);
                    this.moveProgress(newProgress);
                }
            }, 1000);
        },
        endProgress: function () {
            var endProgressTimeout = setTimeout(() => {
                clearTimeout(endProgressTimeout);

                this.$refs.zzUpload.resetProgress();
            }, 5000);
        }
    }
});

// BTN5  EXAMPLE 5
// ----- The component

Vue.component('zz-button-progress', {
    props: ['text'],
    data: function () {
        return {
            progress: null,
            active: false,
            done: false,
            check: false
        };

    },
    methods: {
        /**
                  * Changes the value of the attribute 'zz-button-progress'
                  * Changing its value will change the percentage of the
                  * progress of the button.
                  */
        moveProgress: function (progress) {
            this.progress = progress;
        },
        /**
            * Reset the button progress to its original state.
            */
        resetProgress: function () {
            this.progress = null;
            this.active = false;
            this.done = false;
            this.check = false;
        },
        /**
            * Event handler for click event
            */
        progressClickEvent: function () {
            if (this.active === false && this.done === false) {
                this.active = true;
            }
        },
        /**
            * Event handler for transitionend event
            */
        progressTransitionEndEvent: function (evt) {
            if (this.progress === null && this.active === true) {
                this.progress = 0;

                this.$emit('progress');
            } else
                if (this.done === true) {
                    this.check = true;
                }
        },
        /**
            * Event handler for animationend event
            */
        progressAnimationEndEvent: function (evt) {
            if (evt.animationName == 'progress-done-pre') {
                this.done = true;
                this.active = false;
                this.progress = null;
            } else
                if (evt.animationName == 'progress-done-post') {
                    this.$emit('progress-finished');
                }
        }
    },

    template: `
<button
	v-bind:zz-button-progress="this.progress"
	v-bind:class="['zz-button', {'active': active, 'zz-button-progress-done': done, 'zz-button-progress-done-active': check}]"
	v-on:click="progressClickEvent"
	v-on:transitionend="progressTransitionEndEvent"
	v-on:animationend="progressAnimationEndEvent"
>
	{{ this.text }}
</button>
` });


// ----- VueJS VM

new Vue({
    el: '#app5',
    methods: {
        moveProgress: function (progress = 0) {
            // This is just an example progress.
            // In real-world application, return from ajax process may be used
            var progressTimeout = setTimeout(() => {
                clearTimeout(progressTimeout);

                if (progress < 100) {
                    let newProgress = progress + 1;
                    this.$refs.zzUpload.moveProgress(newProgress);
                    this.moveProgress(newProgress);
                }
            }, 1000);
        },
        endProgress: function () {
            var endProgressTimeout = setTimeout(() => {
                clearTimeout(endProgressTimeout);

                this.$refs.zzUpload.resetProgress();
            }, 5000);
        }
    }
});



