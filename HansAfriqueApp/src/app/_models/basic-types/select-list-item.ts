declare let $: any;

export class SelectListItem {
  value: string;
  text: string;

  constructor(value: any, text: string) {
    this.value = value;
    this.text = text;
  }

  static createTrueFalseSelectListItems(trueText: string, falseText: string): SelectListItem[] {
    const percentageSelectListItem = new SelectListItem(true, trueText);
    const numberSelectListItem = new SelectListItem(false, falseText);
    return [percentageSelectListItem, numberSelectListItem];
  }

  static getSelectListItemFromHtmlSelect(htmlSelectElement: HTMLSelectElement): SelectListItem {
    const $selectElement = $(htmlSelectElement);
    return new SelectListItem(htmlSelectElement.value, $selectElement.text());
  }
}
