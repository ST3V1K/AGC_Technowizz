from PIL import Image, ImageOps
for i in range(1, 904):
    img = Image.open("barcode_" + str(i) + ".jpg")
    color = "white"
    border = (100,100,100,100)
    new_img = ImageOps.expand(img, border=border, fill=color)
    new_img.save("barcode_" + str(i) + ".jpg")