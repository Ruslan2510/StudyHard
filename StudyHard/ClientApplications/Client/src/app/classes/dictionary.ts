export default class Dictionary {
    items = {};

    constructor(keyValuePairs: Object = null) {
        keyValuePairs === null 
            ? (this.items = {}) 
            : (this.items = keyValuePairs);
    }

    public has(key) {
        return key in this.items;
    }

    public set(key, value) {
        this.items[key] = value;
    }

    public get(key) {
        return this.items[key];
    }
    
    public delete(key) {
        if (this.has(key)) {
            delete this.items[key];
            return true;
        }
        return false;
    }
}
