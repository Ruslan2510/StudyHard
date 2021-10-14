"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Dictionary = /** @class */ (function () {
    function Dictionary(keyValuePairs) {
        if (keyValuePairs === void 0) { keyValuePairs = null; }
        this.items = {};
        keyValuePairs === null
            ? (this.items = {})
            : (this.items = keyValuePairs);
    }
    Dictionary.prototype.has = function (key) {
        return key in this.items;
    };
    Dictionary.prototype.set = function (key, value) {
        this.items[key] = value;
    };
    Dictionary.prototype.get = function (key) {
        return this.items[key];
    };
    Dictionary.prototype.delete = function (key) {
        if (this.has(key)) {
            delete this.items[key];
            return true;
        }
        return false;
    };
    return Dictionary;
}());
exports.default = Dictionary;
//# sourceMappingURL=dictionary.js.map